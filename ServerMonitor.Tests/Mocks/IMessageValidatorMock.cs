namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Domain;
    using ServerMonitor.Validators;
    using System;
    using System.Linq.Expressions;

    internal class IMessageValidatorMock : BaseMock<IMessageValidator>
    {
        public void Mock_Validate()
        {
            this.Mock
                .Setup(x => x.ValidateAsync(It.IsAny<Message>()));
        }

        public void Mock_Validate(Expression<Func<Message, bool>> match)
        {
            this.Mock
                .Setup(x => x.ValidateAsync(It.Is(match)));
        }
    }
}
