using ServerMonitor.Config;

namespace ServerMonitor.Validators
{
    internal interface IDiskDriveConfigValidator
    {
        void Validate(DiskDriveConfig diskDriveConfig);
    }
}