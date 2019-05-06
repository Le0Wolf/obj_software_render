using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SoftwareRenderer.ObjReader.Types;

namespace SoftwareRenderer.ObjReader
{
    public class ObjFile : IDisposable
    {
        private StreamReader stream; 
        private List<Vertex> vertexList;
        private List<Face> faceList;

        public Extent Size { get; private set; }

        public IReadOnlyList<Vertex> VertexList => this.vertexList;
        public IReadOnlyList<Face> FaceList => this.faceList;

        public void Load(string path)
        {
            this.Dispose();
            this.stream = new StreamReader(path);
            this.faceList = new List<Face>();
            this.vertexList = new List<Vertex>();
            this.Size = new Extent();

            this.Read();
        }

        public void Dispose()
        {
            this.stream?.Dispose();
        }

        private void Read()
        {
            string line;
            var num = 0;
            while ((line = this.stream.ReadLine()) != null)
            {
                var lineParts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                if (lineParts.Length == 0)
                {
                    continue;
                }

                try
                {
                    this.ParseLine(lineParts);
                }
                catch (Exception e)
                {
                    throw new FormatException($"Parsing exception at line {num}", e);
                }

                num++;
            }

            this.stream.BaseStream.Seek(0, SeekOrigin.Begin);
        }

        private void ParseLine(string[] data)
        {
            switch (data[0])
            {
                case "v":
                    var v = this.LoadType(data, this.vertexList);
                    v.Index = this.vertexList.Count;
                    this.UpdateSizeByVertex(v);
                    break;
                case "f":
                    this.LoadType(data, this.faceList);
                    break;
            }
        }

        private T LoadType<T>(string[] data, IList<T> resultContainer) where T : IType, new()
        {
            var t = new T();
            t.Load(data);
            resultContainer.Add(t);
            return t;
        }

        private void UpdateSizeByVertex(Vertex vertex)
        {
            if (this.Size.XMax < vertex.X)
            {
                this.Size.XMax = vertex.X;
            }

            if (this.Size.YMax < vertex.Y)
            {
                this.Size.YMax = vertex.Y;
            }

            if (this.Size.ZMax < vertex.Z)
            {
                this.Size.ZMax = vertex.Z;
            }

            if (this.Size.XMin > vertex.X)
            {
                this.Size.XMin = vertex.X;
            }

            if (this.Size.YMin > vertex.Y)
            {
                this.Size.YMin = vertex.Y;
            }

            if (this.Size.ZMin > vertex.Z)
            {
                this.Size.ZMin = vertex.Z;
            }
        }
    }
}