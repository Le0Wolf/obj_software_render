using System.Drawing;
using SoftwareRenderer.ObjReader;

namespace SoftwareRenderer
{
    public class Renderer
    {
        private ObjFile obj;

        public bool Loaded { get; private set; }

        public RectangleF Rect { get; private set; }

        public void Load(string path)
        {
            this.obj = new ObjFile(path);
            this.Loaded = true;
        }

        public Settings.Settings Settings { get; set; }

        public Bitmap Render(int width, int height)
        {
            if (this.obj == null)
            {
                return null;
            }

            var bmp = new Bitmap(width, height);
            var meshPen = this.Settings.GetPen();
            var context = new GraphicContext(this.Settings, this.obj, width, height);

            using (var graphic = Graphics.FromImage(bmp))
            {
                this.Rect = RectangleF.Empty;
                this.Clear(graphic);
                this.InnerRender(graphic, meshPen, context);
            }

            return bmp;
        }

        private void InnerRender(Graphics graphics, Pen meshPen, GraphicContext context)
        {
            foreach(var face in this.obj.FaceList)
            {
                for (var i = 0; i < 3; i++)
                {
                    var j = (i + 1) % 3;
                    if (face.VertexIndexList.Length < i || face.VertexIndexList.Length < j)
                    {
                        continue;
                    }

                    var v0Ind = face.VertexIndexList[i];
                    var v1Ind = face.VertexIndexList[j];

                    if (this.obj.VertexList.Count <= v0Ind || this.obj.VertexList.Count <= v1Ind)
                    {
                        continue;
                    }

                    var v0 = this.obj.VertexList[v0Ind - 1];
                    var v1 = this.obj.VertexList[v1Ind - 1];

                    graphics.DrawLine(meshPen, context.GetPoint(v0), context.GetPoint(v1));
                }
            }
        }

        private void Clear(Graphics graphics)
        {
            graphics.Clear(this.Settings.BackgroundColor);
        }
    }
}