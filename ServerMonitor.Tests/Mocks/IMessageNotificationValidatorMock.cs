namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Config;
    using ServerMonitor.Validators;
    using System;
    using System.Linq.Expressions;

    internal class IMessageNotificationValidatorMock : BaseMock<IMessageNotificationValidator>
    {
        public void Mock_Validate(Expression<Func<MessageNotificationConfig, bool>> match)
        {
            this.Mock
                .Setup(x => x.ValidateAsync(It.Is(match)));
        }

        public void Mock_Validate()
        {
            this.Mock
                .Setup(x => x.ValidateAsync(It.IsAny<MessageNotificationConfig>()));
        }

        public void Verify_ValidateCalled(Times times)
        {
            this.Mock
                .Verify(x => x.ValidateAsync(It.IsAny<MessageNotificationConfig>()), times);
        }

        public void Verify_ValidateCalled(Expression<Func<MessageNotificationConfig, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.ValidateAsync(It.Is(match)), times);
        }
    }
}
