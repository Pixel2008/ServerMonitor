namespace ServerMonitor.Tests.Contexts
{
    using ServerMonitor.Validators;

    internal class MessageValidatorContext : BaseContext<MessageValidator>
    {
        public MessageValidatorContext()
        {
            this.Obj = new MessageValidator();
        }
    }
}
