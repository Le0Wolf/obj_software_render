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
        private Func<Vertex, float> xSelector = vertex => vertex.X;
        private Func<Vertex, float> ySelector = vertex => vertex.Y;
        private Func<Extent, float> xSizeSelector = extent => extent.XSize;
        private Func<Extent, float> ySizeSelector = extent => extent.YSize;
        private float userScaleFactor = 1;

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

            this.RenderObj(this.obj, this.xSelector, this.ySelector, this.xSizeSelector, this.ySizeSelector);
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

            this.RenderObj(this.obj, this.xSelector, this.ySelector, this.xSizeSelector, this.ySizeSelector);
        }

        private void RenderObj(
                ObjFile file,
                Func<Vertex, float> xSelector,
                Func<Vertex, float> ySelector,
                Func<Extent, float> xSizeSelector,
                Func<Extent, float> ySizeSelector)
        {
            this.canPaint = false;

            var width = this.canvas.Width;
            var height = this.canvas.Height;

            // Меньше 1 - сжатие, больше 1 - растяжение
            var scaleFactor = Math.Min(width / xSizeSelector(file.Size), height / ySizeSelector(file.Size)) / this.userScaleFactor;

            var wCenter = width / 2;
            var hCenter = height / 2;

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

                    var x0 = wCenter + xSelector(v0) * scaleFactor;
                    var y0 = hCenter + ySelector(v0) * scaleFactor;
                    var x1 = wCenter + xSelector(v1) * scaleFactor;
                    var y1 = hCenter + ySelector(v1) * scaleFactor;

                    graphic.DrawLine(this.pen, x0, y0, x1, y1);
                }
            }

            graphic.Dispose();
            this.canvas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            this.canPaint = true;
        }
    }
}
