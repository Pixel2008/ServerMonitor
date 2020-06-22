using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Config
{
    internal class MemoryConfig : ServiceConfig
    {
        public bool ReportMode { get; set; }
        public int MaxPercentageUsage { get; set; }
    }
}
