using ServerMonitor.Config;
using System.Collections.Generic;

namespace ServerMonitor.Tests.Builders
{
    internal class DiskDriveConfigBuilder
    {
        private readonly DiskDriveConfig config;

        public DiskDriveConfigBuilder()
        {
            this.config = new DiskDriveConfig();
        }
        public DiskDriveConfigBuilder WithDelayStart(int delayStart)
        {
            this.config.DelayStart = delayStart;
            return this;
        }

        public DiskDriveConfigBuilder WithRunInterval(int runInterval)
        {
            this.config.RunInterval = runInterval;
            return this;
        }

        public DiskDriveConfigBuilder WithEnabled(bool enabled)
        {
            this.config.Enabled = enabled;
            return this;
        }

        public DiskDriveConfigBuilder WithPartitions(IList<DiskDriveConfig.Partition> partitions)
        {
            this.config.Partitions = partitions;
            return this;
        }

        public DiskDriveConfigBuilder WithReportMode(bool reportMode)
        {
            this.config.ReportMode = reportMode;
            return this;
        }

        public DiskDriveConfig Build()
        {
            return this.config;
        }
    }
}
