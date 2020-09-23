namespace ServerMonitor.Tests.Contexts
{
    using ServerMonitor.Validators;

    internal class MessageRecipientValidatorContext : BaseContext<MessageRecipientValidator>
    {
        public MessageRecipientValidatorContext()
        {
            this.Obj = new MessageRecipientValidator();
        }
    }
}
