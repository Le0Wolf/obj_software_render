using System;
using System.Drawing;
using System.Globalization;

namespace SoftwareRenderer.ObjReader.Types
{
    public class Vertex : IType
    {
        public const int MinimumDataLength = 1 + 3;
        public const string Prefix = "v";

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float? W { get; set; }

        public int Index { get; set; }

        public void Load(params string[] data)
        {
            if (data.Length < MinimumDataLength)
                throw new ArgumentException($"Input array must be of minimum length {MinimumDataLength}", nameof(data));

            if (!data[0].ToLower().Equals(Prefix))
                throw new ArgumentException("Data prefix must be '" + Prefix + "'", nameof(data));


            this.X = this.Parse(data[1], nameof(this.X));
            this.Y = this.Parse(data[2], nameof(this.Y));
            this.Z = this.Parse(data[3], nameof(this.Z));

            if (data.Length > MinimumDataLength)
            {
                this.W = this.Parse(data[4], nameof(this.W));
            }
        }

        private float Parse(string value, string name)
        {
            if (!float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {
                throw new ArgumentException($"Could not parse {name} parameter as double. Value = {value}");
            }

            return result;
        }

        public PointF ToPointF(int width, int height)
        {
            var newX = (this.X + 1) * width / 2;
            var newY = (this.Y + 1) * height / 2;
            return new PointF(newX, newY);
        }

        public override string ToString()
        {
            return $"v {this.X} {this.Y} {this.Z} {this.W}";
        }
    }
}