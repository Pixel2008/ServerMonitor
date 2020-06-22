using ServerMonitor.Config;

namespace ServerMonitor.Validators
{
    internal interface ISMTPValidator
    {
        void Validate(SMTP smtp);
    }
}