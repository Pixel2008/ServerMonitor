namespace ServerMonitor.Services
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using ServerMonitor.Components;
    using ServerMonitor.Config;
    using ServerMonitor.Core;
    using ServerMonitor.Validators;

    internal class MessageSenderService : IMessageSenderService, ITestMode
    {
        #region Members
        private readonly IMessageNotificationValidator messageNotificationValidator;
        private readonly IMessageQueueService messageQueueService;
        private readonly IMessageSender messageSender;
        private readonly IOptions<AppConfig> config;
        private readonly ILogger<MessageSenderService> logger;
        #endregion

        #region .ctor
        public MessageSenderService(IMessageNotificationValidator messageNotificationValidator, IMessageQueueService messageQueue, IMessageSender messageSender, IOptions<AppConfig> config, ILogger<MessageSenderService> logger)
        {
            this.messageNotificationValidator = messageNotificationValidator;
            this.messageQueueService = messageQueue;
            this.messageSender = messageSender;
            this.config = config;
            this.logger = logger;
        }
        #endregion

        #region Methods
        public bool Enabled => this.config.Value.MessageNotification.Enabled;
        public double Interval => this.config.Value.MessageNotification.RunInterval;
        public double Delay => this.config.Value.MessageNotification.DelayStart;

        public void DoWork()
        {
            int maxQuantity = this.config.Value.MessageNotification.Limit;
            logger.LogDebug($"maxQuantity={maxQuantity}");

            int counter = 0;
            while (counter++ < maxQuantity)
            {
                var mail = this.messageQueueService.Dequeue();
                if (mail == null)
                {
                    break;
                }

                this.logger.LogDebug(mail.Debug);

                this.messageSender.SendMessage(mail);
            }
        }

        public void Validate()
        {
            this.messageNotificationValidator.Validate(this.config?.Value?.MessageNotification);
        }
        #endregion
    }
}
