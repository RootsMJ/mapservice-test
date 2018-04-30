using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Contracts
{
    public class Layer
    {
        public double CurrentVersion { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string DefinitionExpression { get; set; }
        public string GeometryType { get; set; }
        public string CopyrightText { get; set; }
        public object ParentLayer { get; set; }
        public IEnumerable<object> SubLayers { get; set; }
        public double MinScale { get; set; }
        public double MaxScale { get; set; }
        public bool DefaultVisibility { get; set; }
        public Extent Extent { get; set; }
        public bool HasAttachments { get; set; }
        public TimeInfo TimeInfo { get; set; }
        public DrawingInfo DrawingInfo { get; set; }
        public string DisplayField { get; set; }
        public IEnumerable<Field> Fields { get; set; }
        public IEnumerable<Relationship> Relationships { get; set; }
        public string Capabilities { get; set; }
    }
}