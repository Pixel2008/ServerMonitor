using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using ServerMonitor.Config;
using ServerMonitor.Converters;
using ServerMonitor.Domain;
using ServerMonitor.Validators;

namespace ServerMonitor.Tests
{
    internal class MimeMessageConverterContext
    {
        private MimeMessageConverter obj;
        private readonly Mock<IOptions<AppConfig>> mockConfig;
        private readonly Mock<IMessageValidator> mockMessageValidator;
        public MimeMessageConverterContext()
        {
            this.mockConfig = new Mock<IOptions<AppConfig>>();

            this.mockMessageValidator = new Mock<IMessageValidator>();
            this.mockMessageValidator.Setup(x => x.Validate(It.IsAny<Message>()));

            var logger = new NullLogger<MimeMessageConverter>();

            this.obj = new MimeMessageConverter(this.mockConfig.Object, this.mockMessageValidator.Object, logger);
        }
        public MimeMessageConverterContext WithAppConfig(AppConfig appConfig)
        {
            this.mockConfig.Setup(x => x.Value).Returns(appConfig);
            return this;
        }
        public MimeMessageConverter Build()
        {
            return this.obj;
        }
    }
}
