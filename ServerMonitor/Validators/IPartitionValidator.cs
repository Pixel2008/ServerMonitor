using static ServerMonitor.Config.DiskDriveConfig;

namespace ServerMonitor.Validators
{
    internal interface IPartitionValidator
    {
        void Validate(Partition partition);
    }
}