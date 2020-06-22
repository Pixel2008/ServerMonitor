using ServerMonitor.Config;

namespace ServerMonitor.Tests.Builders
{
    internal class MemoryConfigBuilder
    {
        private readonly MemoryConfig config;

        public MemoryConfigBuilder()
        {
            this.config = new MemoryConfig();
        }
        public MemoryConfigBuilder WithDelayStart(int delayStart)
        {
            this.config.DelayStart = delayStart;
            return this;
        }

        public MemoryConfigBuilder WithRunInterval(int runInterval)
        {
            this.config.RunInterval = runInterval;
            return this;
        }

        public MemoryConfigBuilder WithEnabled(bool enabled)
        {
            this.config.Enabled = enabled;
            return this;
        }

        public MemoryConfigBuilder WithMaxPercentageUsage(int maxPercentageUsage)
        {
            this.config.MaxPercentageUsage = maxPercentageUsage;
            return this;
        }

        public MemoryConfigBuilder WithReportMode(bool reportMode)
        {
            this.config.ReportMode = reportMode;
            return this;
        }

        public MemoryConfig Build()
        {
            return this.config;
        }
    }
}
