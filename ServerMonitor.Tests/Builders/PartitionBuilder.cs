namespace ServerMonitor.Tests.Builders
{
    using static ServerMonitor.Config.DiskDriveConfig;

    internal class PartitionBuilder : BaseBuilder<Partition>
    {
        public PartitionBuilder WithPath(string path)
        {
            this.Obj.Path = path;
            return this;
        }
        public PartitionBuilder WithMinPercentageUsage(int minPercentageUsage)
        {
            this.Obj.MaxPercentageUsage = minPercentageUsage;
            return this;
        }        
    }
}
