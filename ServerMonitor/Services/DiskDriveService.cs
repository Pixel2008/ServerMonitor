namespace ServerMonitor.Services
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using ServerMonitor.Components;
    using ServerMonitor.Config;
    using ServerMonitor.Converters;
    using ServerMonitor.Validators;

    internal class DiskDriveService : IDiskDriveService
    {
        #region Members
        private readonly IOptions<AppConfig> config;
        private readonly IDiskDriveConfigValidator diskDriveConfigValidator;
        private readonly IMessageConverter messageConverter;
        private readonly IDiskDriveInfo diskDriveInfo;
        private readonly IMessageQueueService messageQueueService;
        private readonly ILogger<DiskDriveService> logger;
        #endregion

        #region .ctor
        public DiskDriveService(IOptions<AppConfig> config,IDiskDriveConfigValidator diskDriveConfigValidator, IMessageConverter messageConverter, IDiskDriveInfo diskDriveInfo, IMessageQueueService messageQueueService, ILogger<DiskDriveService> logger)
        {
            this.config = config;
            this.diskDriveConfigValidator = diskDriveConfigValidator;
            this.messageConverter = messageConverter;
            this.diskDriveInfo = diskDriveInfo;
            this.messageQueueService = messageQueueService;
            this.logger = logger;
        }
        #endregion

        #region Members
        public bool Enabled => this.config.Value.DiskDrive.Enabled;
        public double Interval => this.config.Value.DiskDrive.RunInterval;
        public double Delay => this.config.Value.DiskDrive.DelayStart;

        public void DoWork()
        {
            foreach (var partition in this.config.Value.DiskDrive.Partitions)
            {
                logger.LogDebug(partition.Debug);

                var metrics = this.diskDriveInfo.GetDiskDriveMetrics(partition);

                var message = this.messageConverter.Get(metrics);

                if (message != null)
                {
                    this.messageQueueService.Enqueue(message);
                }
            }
        }

        public void Validate()
        {
            this.diskDriveConfigValidator.Validate(this.config?.Value?.DiskDrive);
        }
        #endregion
    }
}
