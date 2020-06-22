using static ServerMonitor.Config.DiskDriveConfig;

namespace ServerMonitor.Tests.Builders
{
    internal class PartitionBuilder
    {
        private readonly Partition partition;

        public PartitionBuilder()
        {
            this.partition = new Partition();
        }
        public PartitionBuilder WithPath(string path)
        {
            this.partition.Path = path;
            return this;
        }
        public PartitionBuilder WithMinPercentageUsage(int minPercentageUsage)
        {
            this.partition.MinPercentageUsage = minPercentageUsage;
            return this;
        }
        public Partition Build()
        {
            return this.partition;
        }
    }
}
