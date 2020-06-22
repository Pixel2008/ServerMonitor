using ServerMonitor.Validators;

namespace ServerMonitor.Tests.Validators
{
    internal class SMTPValidatorContext
    {
        private readonly SMTPValidator obj;

        public SMTPValidatorContext()
        {
            this.obj = new SMTPValidator();
        }

        public SMTPValidator Build()
        {
            return this.obj;
        }
    }
}
