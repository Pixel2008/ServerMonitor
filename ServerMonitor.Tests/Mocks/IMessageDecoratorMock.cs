namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Components;
    using ServerMonitor.Domain;
    using System;
    using System.Linq.Expressions;

    internal class IMessageDecoratorMock : BaseMock<IMessageDecorator>
    {
        public void Mock_GetMessage(Message response)
        {
            this.Mock
                .Setup(x => x.GetMessageAsync(It.IsAny<Message>()))
                .ReturnsAsync(response);
        }

        public void Mock_GetMessage(Expression<Func<Message, bool>> match, Message response)
        {
            this.Mock
                .Setup(x => x.GetMessageAsync(It.Is(match)))
                .ReturnsAsync(response);
        }

        public void Verify_GetMessageCalled(Times times)
        {
            this.Mock
                .Verify(x => x.GetMessageAsync(It.IsAny<Message>()), times);
        }

        public void Verify_GetMessageCalled(Expression<Func<Message, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.GetMessageAsync(It.Is(match)), times);
        }
    }
}
