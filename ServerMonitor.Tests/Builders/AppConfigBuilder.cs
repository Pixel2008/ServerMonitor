using ServerMonitor.Config;

namespace ServerMonitor.Tests.Builders
{
    internal class AppConfigBuilder
    {
        private readonly AppConfig config;

        public AppConfigBuilder()
        {
            this.config = new AppConfig();
        }

        public AppConfigBuilder WithTest(bool test)
        {
            this.config.Test = test;
            return this;
        }

        public AppConfigBuilder WithDiskDrive(DiskDriveConfig diskDriveConfig)
        {
            this.config.DiskDrive = diskDriveConfig;
            return this;
        }

        public AppConfigBuilder WithMemory(MemoryConfig memoryConfig)
        {
            this.config.Memory = memoryConfig;
            return this;
        }

        public AppConfigBuilder WithMessageNotification(MessageNotificationConfig messageNotificationConfig)
        {
            this.config.MessageNotification = messageNotificationConfig;
            return this;
        }

        public AppConfigBuilder WithSMTP(SMTP smtp)
        {
            this.config.SMTP = smtp;
            return this;
        }

        public AppConfig Build()
        {
            return this.config;
        }
    }
}
