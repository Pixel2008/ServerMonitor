namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Config;

    internal class MemoryConfigBuilder : BaseBuilder<MemoryConfig>
    {
        public MemoryConfigBuilder WithDelayStart(int delayStart)
        {
            this.Obj.DelayStart = delayStart;
            return this;
        }

        public MemoryConfigBuilder WithRunInterval(int runInterval)
        {
            this.Obj.RunInterval = runInterval;
            return this;
        }

        public MemoryConfigBuilder WithEnabled(bool enabled)
        {
            this.Obj.Enabled = enabled;
            return this;
        }

        public MemoryConfigBuilder WithMaxPercentageUsage(int maxPercentageUsage)
        {
            this.Obj.MaxPercentageUsage = maxPercentageUsage;
            return this;
        }

        public MemoryConfigBuilder WithReportMode(bool reportMode)
        {
            this.Obj.ReportMode = reportMode;
            return this;
        }
    }
}
