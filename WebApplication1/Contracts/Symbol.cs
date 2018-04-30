using System.Collections.Generic;

namespace WebApplication1.Contracts
{
    public class Symbol
    {
        public string Type { get; set; }
        public string Style { get; set; }
        public IList<int> Color { get; set; }
        public int Size { get; set; }
        public int Angle { get; set; }
        public int Xoffset { get; set; }
        public int Yoffset { get; set; }
        public Outline Outline { get; set; }
    }
}