using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Contracts
{
    public class ExportImageInfo
    {
        public string Href { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Extent Extent { get; set; }
        public double Scale { get; set; }
    }
}