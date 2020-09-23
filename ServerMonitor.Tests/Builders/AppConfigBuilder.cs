namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Config;

    internal class AppConfigBuilder : BaseBuilder<AppConfig>
    {
        public AppConfigBuilder WithTest(bool test)
        {
            this.Obj.Test = test;
            return this;
        }

        public AppConfigBuilder WithDiskDrive(DiskDriveConfig diskDriveConfig)
        {
            this.Obj.DiskDrive = diskDriveConfig;
            return this;
        }

        public AppConfigBuilder WithMemory(MemoryConfig memoryConfig)
        {
            this.Obj.Memory = memoryConfig;
            return this;
        }

        public AppConfigBuilder WithMessageNotification(MessageNotificationConfig messageNotificationConfig)
        {
            this.Obj.MessageNotification = messageNotificationConfig;
            return this;
        }

        public AppConfigBuilder WithSMTP(SMTP smtp)
        {
            this.Obj.SMTP = smtp;
            return this;
        }
    }
}
