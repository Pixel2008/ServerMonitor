using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Converters
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using MimeKit;
    using ServerMonitor.Config;
    using ServerMonitor.Domain;
    using ServerMonitor.Validators;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    internal class MimeMessageConverter : IMimeMessageConverter
    {
        private readonly IOptions<AppConfig> config;
        private readonly IMessageValidator messageValidator;
        private readonly ILogger<MimeMessageConverter> logger;

        public MimeMessageConverter(IOptions<AppConfig> config, IMessageValidator messageValidator, ILogger<MimeMessageConverter> logger)
        {
            this.config = config;
            this.messageValidator = messageValidator;
            this.logger = logger;
        }

        public async Task<MimeMessage> GetAsync(Message message)
        {
            if (message == null)
            {
                throw new NullReferenceException(nameof(message));
            }

            this.logger.LogDebug(message.Debug);

            await this.messageValidator.ValidateAsync(message);
                        
            var mimeMessage = new MimeMessage
            {
                Subject = message.Title,
                Body = new BodyBuilder() { TextBody = message.Content }.ToMessageBody()
            };

            var config = this.config.Value.MessageNotification;   
            mimeMessage.From.Add(new MailboxAddress(Encoding.UTF8, config.Display, config.From));

            foreach (var recipient in config.MessageRecipients)
            {
                mimeMessage.To.Add(new MailboxAddress(recipient.Address));
            }

            return mimeMessage;
        }
    }
}
