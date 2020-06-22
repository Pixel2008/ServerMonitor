using ServerMonitor.Config;
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
            if (smtp.Port < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Port), $"Minimum value is 1");
            }
            if (smtp.Port > 65536)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Port), $"Maximum value is 65536");
            }

            if (smtp.Timeout < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Timeout), $"Minimum value is 1");
            }
            if (smtp.Timeout > 120)
            {
                throw new ArgumentOutOfRangeException(nameof(smtp.Timeout), $"Maximum value is 120");
            }
        }
    }
}
