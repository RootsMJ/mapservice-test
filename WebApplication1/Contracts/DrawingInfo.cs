namespace WebApplication1.Contracts
{
    public class DrawingInfo
    {
        public Renderer Renderer { get; set; }
        public bool ScaleSymbols { get; set; }
        public int Transparency { get; set; }
        public int Brightness { get; set; }
        public int Contrast { get; set; }
        public object LabelingInfo { get; set; }
    }
}