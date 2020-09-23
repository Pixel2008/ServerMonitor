namespace ServerMonitor.Tests.Contexts
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Mocks;

    internal class MessageSenderServiceContext : BaseContext<MessageSenderService>
    {
        public readonly IMessageNotificationValidatorMock MessageNotificationValidatorMock;
        public readonly IMessageQueueServiceMock MessageQueueServiceMock;
        public readonly IMessageSenderMock MessageSenderMock;
        public readonly IOptionsAppConfigMock ConfigMock;

        public MessageSenderServiceContext()
        {
            this.MessageNotificationValidatorMock = new IMessageNotificationValidatorMock();
            this.MessageQueueServiceMock = new IMessageQueueServiceMock();
            this.MessageSenderMock = new IMessageSenderMock();
            this.ConfigMock = new IOptionsAppConfigMock();

            var loggerMock = new Mock<ILogger<MessageSenderService>>();

            this.Obj = new MessageSenderService(this.MessageNotificationValidatorMock.Object,
                this.MessageQueueServiceMock.Object,
                this.MessageSenderMock.Object,
                this.ConfigMock.Object,
                loggerMock.Object);
        }

    }
}
