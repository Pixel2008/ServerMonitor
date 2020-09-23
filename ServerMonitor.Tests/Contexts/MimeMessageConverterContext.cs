namespace ServerMonitor.Tests.Contexts
{
    using Microsoft.Extensions.Logging.Abstractions;
    using ServerMonitor.Config;
    using ServerMonitor.Converters;
    using ServerMonitor.Tests.Mocks;

    internal class MimeMessageConverterContext : BaseContext<MimeMessageConverter>
    {
        private readonly IOptionsAppConfigMock ConfigMock;
        private readonly IMessageValidatorMock MessageValidatorMock;
        public MimeMessageConverterContext()
        {
            this.ConfigMock = new IOptionsAppConfigMock();

            this.MessageValidatorMock = new IMessageValidatorMock();
            this.MessageValidatorMock.Mock_Validate();
            
            var logger = new NullLogger<MimeMessageConverter>();

            this.Obj = new MimeMessageConverter(this.ConfigMock.Object, this.MessageValidatorMock.Object, logger);
        }
        public MimeMessageConverterContext WithAppConfig(AppConfig appConfig)
        {
            this.ConfigMock.Mock_Config(appConfig);
            return this;
        }        
    }
}
