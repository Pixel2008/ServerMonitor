namespace ServerMonitor.Components
{
    using ServerMonitor.Config;
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IDiskDriveInfo
    {
        Task<DiskDriveMetrics> GetDiskDriveMetricsAsync(DiskDriveConfig.Partition partition);
    }
}
