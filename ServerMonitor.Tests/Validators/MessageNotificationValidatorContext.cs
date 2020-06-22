using Moq;
using ServerMonitor.Config;
using ServerMonitor.Validators;

namespace ServerMonitor.Tests.Validators
{
    internal class MessageNotificationValidatorContext
    {
        private readonly MessageNotificationValidator obj;

        public MessageNotificationValidatorContext()
        {
            var messageRecipientValidatorMock = new Mock<IMessageRecipientValidator>();
            messageRecipientValidatorMock.Setup(x => x.Validate(It.IsAny<MessageRecipient>()));
            this.obj = new MessageNotificationValidator(messageRecipientValidatorMock.Object);
        }

        public MessageNotificationValidator Build()
        {
            return this.obj;
        }
    }
}
