using System.Collections.Generic;

namespace WebApplication1.Contracts
{
    public class LayerWithService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentLayerId { get; set; }
        public bool DefaultVisibility { get; set; }
        public IList<int> SubLayerIds { get; set; }
        public double MinScale { get; set; }
        public int MaxScale { get; set; }
    }
}