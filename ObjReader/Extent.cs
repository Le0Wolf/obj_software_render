namespace SoftwareRenderer.ObjReader
{
    public class Extent
    {
        public float XMax { get; set; }
        public float XMin { get; set; }
        public float YMax { get; set; }
        public float YMin { get; set; }
        public float ZMax { get; set; }
        public float ZMin { get; set; }

        public float XSize => this.XMax - this.XMin;
        public float YSize => this.YMax - this.YMin;
        public float ZSize => this.ZMax - this.ZMin;
    }
}