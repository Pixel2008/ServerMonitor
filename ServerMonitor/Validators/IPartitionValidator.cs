namespace ServerMonitor.Validators
{
    using System.Threading.Tasks;
    using static ServerMonitor.Config.DiskDriveConfig;

    internal interface IPartitionValidator
    {
        Task ValidateAsync(Partition partition);
    }
}