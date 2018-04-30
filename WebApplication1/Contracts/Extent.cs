namespace WebApplication1.Contracts
{
    public class Extent
    {
        public double Xmin { get; set; }
        public double Ymin { get; set; }
        public double Xmax { get; set; }
        public double Ymax { get; set; }
        public SpatialReference SpatialReference { get; set; }
    }
}