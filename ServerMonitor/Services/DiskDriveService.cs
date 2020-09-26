namespace ServerMonitor.Services
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using ServerMonitor.Components;
    using ServerMonitor.Config;
    using ServerMonitor.Converters;
    using ServerMonitor.Validators;
    using System.Threading.Tasks;

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

        public async Task DoWorkAsync()
        {
            foreach (var partition in this.config.Value.DiskDrive.Partitions)
            {
                logger.LogDebug(partition.Debug);

                var metrics = await this.diskDriveInfo.GetDiskDriveMetricsAsync(partition);

                var message = await this.messageConverter.GetAsync(metrics);

                if (message != null)
                {
                    await this.messageQueueService.EnqueueAsync(message);
                }
            }
        }

        public async Task ValidateAsync()
        {
            await this.diskDriveConfigValidator.ValidateAsync(this.config?.Value?.DiskDrive);
        }
        #endregion
    }
}
