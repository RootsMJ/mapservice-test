namespace WebApplication1.Contracts
{
    public class ExportOptions
    {
        public bool UseTime { get; set; }
        public bool TimeDataCumulative { get; set; }
        public object TimeOffset { get; set; }
        public object TimeOffsetUnits { get; set; }
    }
}