namespace ServerMonitor.Tests.Contexts
{
    using ServerMonitor.Validators;

    internal class SMTPValidatorContext : BaseContext<SMTPValidator>
    {
        public SMTPValidatorContext()
        {
            this.Obj = new SMTPValidator();
        }
    }
}
