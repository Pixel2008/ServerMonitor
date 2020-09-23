namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Components;
    using ServerMonitor.Domain;
    using System;
    using System.Linq.Expressions;

    internal class IMessageSenderMock : BaseMock<IMessageSender>
    {
        public void Mock_SendMessage()
        {
            this.Mock
                .Setup(x => x.SendMessage(It.IsAny<Message>()));
        }

        public void Mock_SendMessage(Expression<Func<Message, bool>> match)
        {
            this.Mock
                .Setup(x => x.SendMessage(It.Is(match)));
        }

        public void Veirfy_SendMessageCalled(Times times)
        {
            this.Mock
                .Verify(x => x.SendMessage(It.IsAny<Message>()), times);
        }

        public void Verify_SendMessageCalled(Expression<Func<Message, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.SendMessage(It.Is(match)), times);
        }
    }
}
