using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using SoftwareRenderer.ObjReader;
using SoftwareRenderer.ObjReader.Types;

namespace SoftwareRenderer
{
    public partial class MainForm : Form
    {
        private ObjFile obj;
        private Pen pen;
        private bool canPaint = true;

        public MainForm()
        {
            this.InitializeComponent();
            this.pen = new Pen(Color.White);
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openModelDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                this.obj = new ObjFile();
                this.obj.Load(this.openModelDlg.FileName);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                                $"Details:\n\n{ex.StackTrace}");
                return;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Parsing error.\n\nError message: {ex.Message}\n\n" +
                                $"Details:\n\n{ex.InnerException.Message}");
                return;
            }

            this.RenderObj(this.obj);
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveBmpDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.canvas.Image.Save(this.saveBmpDlg.FileName);
        }

        private void RefreshMenuItem_Click(object sender, EventArgs e)
        {
            if (this.obj == null || !this.canPaint)
            {
                return;
            }

            this.RenderObj(this.obj);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (true ||this.obj == null || !this.canPaint)
            {
                return;
            }

            this.RenderObj(this.obj);
        }

        private void RenderObj(ObjFile file)
        {
            this.canPaint = false;

            var width = this.canvas.Width;
            var height = this.canvas.Height;

            var wCenter = width / 2;
            var hCenter = height / 2;

            var xOffset = (float) (file.Size.XMin < 0 ? Math.Ceiling(Math.Abs(file.Size.XMin)) : 0);
            var yOffset = (float) (file.Size.YMin < 0 ? Math.Ceiling(Math.Abs(file.Size.YMin)) : 0);

            this.canvas.Image?.Dispose();
            this.canvas.Image = new Bitmap(width, height);

            var graphic = Graphics.FromImage(this.canvas.Image);

            graphic.Clear(Color.Black);
            foreach (var face in file.FaceList)
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

                    if (file.VertexList.Count <= v0Ind || file.VertexList.Count <= v1Ind)
                    {
                        continue;
                    }

                    var v0 = file.VertexList[v0Ind - 1];
                    var v1 = file.VertexList[v1Ind - 1];

                    var x0 = (v0.X + xOffset) * wCenter;
                    var y0 = (v0.Y + yOffset) * hCenter;
                    var x1 = (v1.X + xOffset) * wCenter;
                    var y1 = (v1.Y + yOffset) * hCenter;

                    graphic.DrawLine(this.pen, x0, y0, x1, y1);
                }

                //var dots = this.FaceToPointFArray(face, file.VertexList, width, height);
                //if (dots != null)
                //{
                //    graphic.DrawPolygon(pen, dots);
                //}

            }

            graphic.Dispose();
            this.canvas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            this.canPaint = true;
        }

        private PointF[] FaceToPointFArray(Face face, IReadOnlyList<Vertex> vertices, int width, int height)
        {
            var result = new PointF[2];

            for (var i = 0; i < 2; i++)
            {
                var index = face.VertexIndexList[i];
                if (vertices.Count <= index)
                {
                    return null;
                }

                var point = vertices[index - 1].ToPointF(width, height);
                result[i] = point;
            }

            return result;
        }
    }
}
