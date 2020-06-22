using ServerMonitor.Validators;

namespace ServerMonitor.Tests.Validators
{
    internal class MessageValidatorContext
    {
        private readonly MessageValidator obj;

        public MessageValidatorContext()
        {
            this.obj = new MessageValidator();
        }

        public MessageValidator Build()
        {
            return this.obj;
        }
    }
}
