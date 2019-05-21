using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using SoftwareRenderer.Settings;

namespace SoftwareRenderer
{
    public partial class MainForm : Form
    {
        private readonly Renderer renderer;

        private PointF moveStart;

        private bool canPaint = true;

        public MainForm()
        {
            this.InitializeComponent();
            this.MouseWheel += this.OnMouseWheel;
            this.renderer = new Renderer();
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 0)
            {
                return;
            }

            var delta = this.scaleInput.Increment;
            if (e.Delta < 0)
            {
                delta *= -1;
            }

            var settings = this.renderer.Settings;

            var newScale = settings.Scale + (float) delta;
            if (newScale > (float) this.scaleInput.Maximum || newScale < (float)this.scaleInput.Minimum)
            {
                return;
            }

            settings.Scale = newScale;
            this.scaleInput.Value = (decimal)newScale;
            this.Render();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var settings = Settings.Settings.Load() ?? new Settings.Settings();
            this.renderer.Settings = settings;
            this.backgroundColorButton.BackColor = settings.BackgroundColor;
            this.meshColorButton.BackColor = settings.MeshColor;
            this.projectionCombo.SelectedIndex = this.projectionCombo.Items.IndexOf(settings.Projection.ToString());
            this.centerToXButton.Checked = settings.ChangeCenterX;
            this.centerToYButton.Checked = settings.ChangeCenterY;
            this.scaleInput.Value = (decimal) settings.Scale;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.renderer.Settings.Save();
        }

        private void OpenClick(object sender, EventArgs e)
        {
            if (this.openModelDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                this.renderer.Load(this.openModelDlg.FileName);
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

            this.Render();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (this.saveBmpDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.canvas.Image.Save(this.saveBmpDlg.FileName);
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            if (!this.renderer.Loaded || !this.canPaint)
            {
                return;
            }

            this.Render();
        }

        private void Render()
        {
            if (!this.renderer.Loaded)
            {
                return;
            }

            this.canPaint = false;

            var bmp = this.renderer.Render(this.canvas.Width, this.canvas.Height);

            this.canvas.Image?.Dispose();
            this.canvas.Image = bmp; 
            this.canvas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            this.canPaint = true;
        }

        private void BackgroundColorClick(object sender, EventArgs e)
        {
            if (this.backgroundColorDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.renderer.Settings.BackgroundColor = this.backgroundColorDialog.Color;
            this.backgroundColorButton.BackColor = this.backgroundColorDialog.Color;
            this.Render();
        }

        private void MeshColorClick(object sender, EventArgs e)
        {
            if (this.meshColorDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.renderer.Settings.MeshColor = this.meshColorDialog.Color;
            this.meshColorButton.BackColor = this.meshColorDialog.Color;
            this.Render();
        }

        private void ProjectionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(this.projectionCombo.SelectedItem as string, out Projection projection))
            {
                this.renderer.Settings.Projection = projection;
                this.Render();
            }
        }

        private void CenterToYButton_CheckedChanged(object sender, EventArgs e)
        {
            this.renderer.Settings.ChangeCenterY = this.centerToYButton.Checked;
            this.Render();
        }

        private void CenterToXButton_CheckedChanged(object sender, EventArgs e)
        {
            this.renderer.Settings.ChangeCenterX = this.centerToXButton.Checked;
            this.Render();
        }

        private void ScaleInput_ValueChanged(object sender, EventArgs e)
        {
            this.renderer.Settings.Scale = (float)this.scaleInput.Value;
            this.Render();
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            this.canvas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.renderer.Loaded)
            {
                return;
            }

            this.moveStart = new PointF(e.X, e.Y);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !this.moveStart.IsEmpty)
            {
                var delta = new PointF(this.moveStart.X - e.X, this.moveStart.Y - e.Y);
                this.renderer.Settings.Offset = delta;
                this.Render();
            }
            
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.renderer.Settings.Offset = PointF.Empty;
                this.Render();
            }
        }
    }
}
