namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Domain;
    using ServerMonitor.Services;
    using System;
    using System.Linq.Expressions;

    internal class IMessageQueueServiceMock : BaseMock<IMessageQueueService>
    {
        public void Mock_Enqueue()
        {
            this.Mock
                .Setup(x => x.EnqueueAsync(It.IsAny<Message>()));
        }

        public void Mock_Enqueue(Expression<Func<Message, bool>> match)
        {
            this.Mock
                .Setup(x => x.EnqueueAsync(It.Is(match)));
        }

        public void Verify_EnqueueCalled(Expression<Func<Message, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.EnqueueAsync(It.Is(match)), times);
        }
        public void Verify_EnqueueCalled(Times times)
        {
            this.Mock
                .Verify(x => x.EnqueueAsync(It.IsAny<Message>()), times);
        }

        public void Mock_Dequeue(Message response)
        {
            this.Mock
                .Setup(x => x.DequeueAsync())
                .ReturnsAsync(response);
        }

        public void Verify_DequeueCalled(Times times)
        {
            this.Mock
                .Verify(x => x.DequeueAsync(), times);
        }
    }
}
