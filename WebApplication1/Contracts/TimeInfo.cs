using System.Collections.Generic;

namespace WebApplication1.Contracts
{
    public class TimeInfo
    {
        public string StartTimeField { get; set; }
        public string EndTimeField { get; set; }
        public object TrackIdField { get; set; }
        public IList<long> TimeExtent { get; set; }
        public object TimeReference { get; set; }
        public int TimeInterval { get; set; }
        public string TimeIntervalUnits { get; set; }
        public ExportOptions ExportOptions { get; set; }
    }
}