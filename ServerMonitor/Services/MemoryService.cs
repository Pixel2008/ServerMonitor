namespace ServerMonitor.Services
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using ServerMonitor.Components;
    using ServerMonitor.Config;
    using ServerMonitor.Converters;
    using ServerMonitor.Validators;

    internal class MemoryService : IMemoryService
    {
        #region Members
        private readonly IOptions<AppConfig> config;
        private readonly IMemoryConfigValidator memoryConfigValidator;
        private readonly IMessageConverter messageConverter;
        private readonly IMemoryInfo memoryInfo;
        private readonly IMessageQueueService messageQueue;
        private readonly ILogger<MemoryService> logger;
        #endregion

        #region ctor
        public MemoryService(IOptions<AppConfig> config, IMemoryConfigValidator memoryConfigValidator, IMessageConverter messageConverter, IMemoryInfo memoryInfo, IMessageQueueService messageQueue, ILogger<MemoryService> logger)
        {
            this.config = config;
            this.memoryConfigValidator = memoryConfigValidator;
            this.messageConverter = messageConverter;
            this.memoryInfo = memoryInfo;
            this.messageQueue = messageQueue;
            this.logger = logger;
        }
        #endregion

        #region Methods
        public bool Enabled => this.config.Value.Memory.Enabled;
        public double Interval => this.config.Value.Memory.RunInterval;
        public double Delay => this.config.Value.Memory.DelayStart;

        public void DoWork()
        {
            var memory = this.memoryInfo.GetMemoryMetrics();

            this.logger.LogDebug(memory.Debug);

            var message = this.messageConverter.Get(memory);

            if (message != null)
            {
                this.messageQueue.Enqueue(message);
            }
        }

        public void Validate()
        {
            this.memoryConfigValidator.Validate(this.config?.Value?.Memory);
        }
        #endregion
    }
}
