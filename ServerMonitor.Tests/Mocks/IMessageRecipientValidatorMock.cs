namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Config;
    using ServerMonitor.Validators;
    using System;
    using System.Linq.Expressions;

    internal class IMessageRecipientValidatorMock : BaseMock<IMessageRecipientValidator>
    {
        public void Mock_Validate()
        {
            this.Mock
                .Setup(x => x.ValidateAsync(It.IsAny<MessageRecipient>()));
        }
        public void Verify_ValidateCalled(Expression<Func<MessageRecipient, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.ValidateAsync(It.Is(match)), times);
        }
    }
}
