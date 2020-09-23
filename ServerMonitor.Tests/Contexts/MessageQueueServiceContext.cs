namespace ServerMonitor.Tests.Contexts
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Mocks;

    internal class MessageQueueServiceContext : BaseContext<MessageQueueService>
    {
        public readonly IMessageDecoratorMock MessageDecoratorMock;

        public MessageQueueServiceContext()
        {
            this.MessageDecoratorMock = new IMessageDecoratorMock();

            var loggerMock = new Mock<ILogger<MessageQueueService>>();

            this.Obj = new MessageQueueService(this.MessageDecoratorMock.Object,            
                loggerMock.Object);
        }

    }
}
