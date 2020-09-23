using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Config
{
    internal class DiskDriveConfig : ServiceConfig
    {
        internal class Partition
        {
            public string Path { get; set; }
            public int MaxPercentageUsage { get; set; }

            public string Debug => $"{GetType().Name}:" +
                $"{nameof(Path)}:{Path}," +
                $"{nameof(MaxPercentageUsage)}={MaxPercentageUsage}";
        }

        public bool ReportMode { get; set; }
        public IList<Partition> Partitions { get; set; }
    }
}
