namespace ServerMonitor.Validators
{
    using ServerMonitor.Config;
    using System.Threading.Tasks;

    internal interface IDiskDriveConfigValidator
    {
        Task ValidateAsync(DiskDriveConfig diskDriveConfig);
    }
}