using System.Drawing;

namespace SoftwareRenderer.Settings
{
    public enum Projection
    {
        X,
        Y,
        Z
    }

    public class Settings : BaseSettings<Settings>
    {
        public Color BackgroundColor { get; set; } = Color.Black;
        public Color MeshColor { get; set; } = Color.White;
        public float Scale { get; set; } = 1;
        public Projection Projection { get; set; }
        public bool ChangeCenterX { get; set; }
        public bool ChangeCenterY { get; set; }
        public PointF Offset { get; set; } = PointF.Empty;

        public Pen GetPen()
        {
            return new Pen(this.MeshColor);
        }
    }
}