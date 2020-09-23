namespace ServerMonitor.Tests.Contexts
{
    using ServerMonitor.Tests.Mocks;
    using ServerMonitor.Validators;

    internal class MessageNotificationValidatorContext : BaseContext<MessageNotificationValidator>
    {
        public MessageNotificationValidatorContext()
        {
            var messageRecipientValidatorMock = new IMessageRecipientValidatorMock();
            messageRecipientValidatorMock.Mock_Validate();

            this.Obj = new MessageNotificationValidator(messageRecipientValidatorMock.Object);
        }
    }
}
