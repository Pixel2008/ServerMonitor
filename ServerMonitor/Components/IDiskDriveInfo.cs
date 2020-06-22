using ServerMonitor.Config;
using ServerMonitor.Domain;

namespace ServerMonitor.Components
{
    internal interface IDiskDriveInfo
    {
        DiskDriveMetrics GetDiskDriveMetrics(DiskDriveConfig.Partition partition);
    }
}
