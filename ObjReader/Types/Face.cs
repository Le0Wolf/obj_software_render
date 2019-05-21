using System;
using System.Globalization;
using System.Text;

namespace SoftwareRenderer.ObjReader.Types
{
    public class Face : IType
    {
        public const int MinimumDataLength = 4;
        public const string Prefix = "f";

        public int[] VertexIndexList { get; set; }
        public int[] TextureVertexIndexList { get; set; }

        public void Load(params string[] data)
        {
            if (data.Length < MinimumDataLength)
                throw new ArgumentException($"Input array must be of minimum length {MinimumDataLength}", nameof(data));

            if (!data[0].ToLower().Equals(Prefix))
                throw new ArgumentException("Data prefix must be '" + Prefix + "'", nameof(data));

            var vCount = data.Length - 1;
            this.VertexIndexList = new int[vCount];
            this.TextureVertexIndexList = new int[vCount];

            for (var i = 0; i < vCount; i++)
            {
                var parts = data[i + 1].Split('/');

                this.VertexIndexList[i] = this.Parse(parts[0]);

                if (parts.Length > 1)
                {
                    if (this.TryParse(parts[1], out var vIndex))
                    {
                        this.TextureVertexIndexList[i] = vIndex;
                    }
                }
            }
        }

        private bool TryParse(string value, out int result)
        {
            return int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        private int Parse(string value)
        {
            if(!int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {
                throw new ArgumentException("Could not parse parameter as int");
            }

            return result;
        }

        // HACKHACK this will write invalid files if there are no texture vertices in
        // the faces, need to identify that and write an alternate format
        public override string ToString()
        {
            var b = new StringBuilder();
            b.Append(Prefix);

            for (var i = 0; i < this.VertexIndexList.Length; i++)
            {
                if (i < this.TextureVertexIndexList.Length)
                {
                    b.AppendFormat(" {0}/{1}", this.VertexIndexList[i], this.TextureVertexIndexList[i]);
                }
                else
                {
                    b.AppendFormat(" {0}", this.VertexIndexList[i]);
                }
            }

            return b.ToString();
        }
    }
}