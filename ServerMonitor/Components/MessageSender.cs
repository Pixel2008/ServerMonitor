namespace ServerMonitor.Components
{
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using ServerMonitor.Converters;
    using ServerMonitor.Config;
    using ServerMonitor.Domain;
    using System;
    using ServerMonitor.Validators;
    using System.Threading.Tasks;

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
        public async Task SendMessageAsync(Message message)
        {
            if (message == null)
            {
                throw new NullReferenceException(nameof(message));
            }

            var config = this.config?.Value?.SMTP;

            await this.smtpValidator.ValidateAsync(config);

            this.logger.LogDebug($"{config.Debug} {message.Debug}");

            using var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true,
                Timeout = config.Timeout * 1000
            };

            var msg = await this.mimeMessageConverter.GetAsync(message);
            if (this.config.Value.Test)
            {
                msg.Subject = $"TEST - " + msg.Subject;
            }

            await client.ConnectAsync(config.Server, config.Port, MailKit.Security.SecureSocketOptions.Auto);
            try
            {
                await client.AuthenticateAsync(config.Username, config.Password);
                await client.SendAsync(msg);
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
        #endregion
    }
}
