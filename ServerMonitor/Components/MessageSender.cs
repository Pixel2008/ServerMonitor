using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServerMonitor.Converters;
using ServerMonitor.Config;
using ServerMonitor.Domain;
using System;
using ServerMonitor.Validators;

namespace ServerMonitor.Components
{
    internal class MessageSender : IMessageSender
    {
        #region Members
        private readonly IOptions<AppConfig> config;
        private readonly ISMTPValidator smtpValidator;
        private readonly IMimeMessageConverter mimeMessageConverter;
        private readonly ILogger<MessageSender> logger;
        #endregion

        #region .ctor
        public MessageSender(IOptions<AppConfig> config, ISMTPValidator smtpValidator, IMimeMessageConverter mimeMessageConverter, ILogger<MessageSender> logger)
        {
            this.config = config;
            this.smtpValidator = smtpValidator;
            this.mimeMessageConverter = mimeMessageConverter;
            this.logger = logger;
        }
        #endregion

        #region Methods
        public void SendMessage(Message message)
        {
            try
            {
                var config = this.config?.Value?.SMTP;

                this.smtpValidator.Validate(config);                                

                this.logger.LogDebug($"{config.Debug} {message.Debug}");

                using var client = new SmtpClient
                {
                    ServerCertificateValidationCallback = (s, c, h, e) => true,
                    Timeout = config.Timeout * 1000
                };

                var msg = this.mimeMessageConverter.Get(message);
                if(this.config.Value.Test)
                {
                    msg.Subject = $"TEST - " + msg.Subject;
                }

                client.Connect(config.Server, config.Port, MailKit.Security.SecureSocketOptions.Auto);
                try
                {
                    client.Authenticate(config.Username, config.Password);
                    client.Send(msg);
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogCritical(ex, $"An exception occured while sending mail: {message.Title}.");
            }
        }
        #endregion
    }
}
