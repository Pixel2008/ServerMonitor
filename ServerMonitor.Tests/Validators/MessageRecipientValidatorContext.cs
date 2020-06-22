using ServerMonitor.Validators;

namespace ServerMonitor.Tests.Validators
{
    internal class MessageRecipientValidatorContext
    {
        private readonly MessageRecipientValidator obj;

        public MessageRecipientValidatorContext()
        {
            this.obj = new MessageRecipientValidator();
        }

        public MessageRecipientValidator Build()
        {
            return this.obj;
        }
    }
}
