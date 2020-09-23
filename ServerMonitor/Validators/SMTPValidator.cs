using ServerMonitor.Config;
using ServerMonitor.Consts;
using System;

namespace ServerMonitor.Validators
{
    internal class SMTPValidator : ISMTPValidator
    {
        public void Validate(SMTP smtp)
        {
            if (smtp == null)
            {
                throw new ArgumentNullException(nameof(smtp));
            }            
            if (string.IsNullOrWhiteSpace(smtp.Server))
            {
                throw new ArgumentNullException(nameof(smtp.Server));
            }
            if (smtp.Port < AppConsts.SMTP_PORT_MIN)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Port), $"Minimum value is {AppConsts.SMTP_PORT_MIN}");
            }
            if (smtp.Port > AppConsts.SMTP_PORT_MAX)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Port), $"Maximum value is {AppConsts.SMTP_PORT_MAX}");
            }
            if (smtp.Timeout < AppConsts.SMTP_TIMEOUT_MIN)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Timeout), $"Minimum value is {AppConsts.SMTP_TIMEOUT_MIN}");
            }
            if (smtp.Timeout > AppConsts.SMTP_TIMEOUT_MAX)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Timeout), $"Maximum value is {AppConsts.SMTP_TIMEOUT_MAX}");
            }
        }
    }
}
