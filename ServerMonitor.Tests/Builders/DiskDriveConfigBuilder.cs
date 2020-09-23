namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Config;
    using System.Collections.Generic;

    internal class DiskDriveConfigBuilder : BaseBuilder<DiskDriveConfig>
    {
        public DiskDriveConfigBuilder WithDelayStart(int delayStart)
        {
            this.Obj.DelayStart = delayStart;
            return this;
        }

        public DiskDriveConfigBuilder WithRunInterval(int runInterval)
        {
            this.Obj.RunInterval = runInterval;
            return this;
        }

        public DiskDriveConfigBuilder WithEnabled(bool enabled)
        {
            this.Obj.Enabled = enabled;
            return this;
        }

        public DiskDriveConfigBuilder WithPartitions(IList<DiskDriveConfig.Partition> partitions)
        {
            this.Obj.Partitions = partitions;
            return this;
        }

        public DiskDriveConfigBuilder WithReportMode(bool reportMode)
        {
            this.Obj.ReportMode = reportMode;
            return this;
        }
    }
}
