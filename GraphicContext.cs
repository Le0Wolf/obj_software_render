using System;
using System.Drawing;
using SoftwareRenderer.ObjReader;
using SoftwareRenderer.ObjReader.Types;
using SoftwareRenderer.Settings;

namespace SoftwareRenderer
{
    public class GraphicContext
    {
        private readonly PointF center;
        private readonly float scale;
        private readonly Func<Vertex, PointF> rawPointSelector;
        private readonly bool changeCenterX;
        private readonly bool changeCenterY;
        private PointF size;

        public GraphicContext(Settings.Settings settings, ObjFile obj, float width, float height)
        {
            var projection = settings.Projection;
            this.size = this.GetSize(obj.Size, projection);
            this.rawPointSelector = this.GetRawPointSelector(projection);

            this.scale = this.CalculateScale(width, height, this.size, settings.Scale);
            this.center = new PointF(width / 2 + settings.Offset.X, height / 2 + settings.Offset.Y);

            this.changeCenterX = settings.ChangeCenterX;
            this.changeCenterY = settings.ChangeCenterY;
        }

        public PointF GetPoint(Vertex vertex)
        {
            var rawPoint = this.rawPointSelector(vertex);
            var rawX = this.changeCenterX ? rawPoint.X  - this.size.X / 2 : rawPoint.X;
            var rawY = this.changeCenterY ? rawPoint.Y - this.size.Y / 2 : rawPoint.Y;
            var x = this.center.X + rawX * this.scale;
            var y = this.center.Y + rawY * this.scale;
            return new PointF(x, y);
        }

        private float CalculateScale(float width, float height, PointF size, float rawScale)
        {
            return Math.Min(width / size.X, height / size.Y) / rawScale;
        }

        private Func<Vertex, PointF> GetRawPointSelector(Projection projection)
        {
            switch (projection)
            {
                case Projection.X:
                    return v => new PointF(v.X, v.Y);
                case Projection.Y:
                    return v => new PointF(v.X, v.Z);
                case Projection.Z:
                    return v => new PointF(v.Y, v.Z);
                default:
                    throw new ArgumentOutOfRangeException(nameof(projection), projection, null);
            }
        }

        private PointF GetSize(Extent sizeSrc, Projection projection)
        {
            switch (projection)
            {
                case Projection.X:
                    return new PointF(sizeSrc.XSize, sizeSrc.YSize);
                case Projection.Y:
                    return new PointF(sizeSrc.XSize, sizeSrc.ZSize);
                case Projection.Z:
                    return new PointF(sizeSrc.YSize, sizeSrc.ZSize);
                default:
                    throw new ArgumentOutOfRangeException(nameof(projection), projection, null);
            }
        }
    }
}