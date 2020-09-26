namespace ServerMonitor.Components
{
    using ServerMonitor.Config;
    using ServerMonitor.Domain;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    internal class DiskDriveInfo : IDiskDriveInfo
    {
        public Task<DiskDriveMetrics> GetDiskDriveMetricsAsync(DiskDriveConfig.Partition partition)
        {
            if (partition == null)
            {
                throw new NullReferenceException(nameof(partition));
            }

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

            return Task.FromResult(metrics);
        }
    }
}
