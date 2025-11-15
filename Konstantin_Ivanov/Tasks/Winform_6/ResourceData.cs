namespace Winform_6
{
    public class ResourceData
    {
        public float cpuUsage { get; set; }
        public float ramUsagePercent { get; set; }
        public float netRecvKB { get; set; }
        public float netSentKB { get; set; }

        public float netTotalKB => netRecvKB + netSentKB;
    }
}
