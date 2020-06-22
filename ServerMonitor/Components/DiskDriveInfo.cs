using ServerMonitor.Config;
using ServerMonitor.Domain;
using System.IO;

namespace ServerMonitor.Components
{
    internal class DiskDriveInfo : IDiskDriveInfo
    {
        public DiskDriveMetrics GetDiskDriveMetrics(DiskDriveConfig.Partition partition)
        {
            DriveInfo di = new DriveInfo(partition.Path);

            var metrics = new DiskDriveMetrics()
            {
                IsReady = di.IsReady,
                Path = partition.Path
            };

            if (metrics.IsReady)
            {
                metrics.Total = di.TotalSize;
                metrics.Free = di.AvailableFreeSpace;
            }

            return metrics;
        }
    }
}
