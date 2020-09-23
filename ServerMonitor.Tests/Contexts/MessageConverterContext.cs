namespace ServerMonitor.Tests.Contexts
{
    using Microsoft.Extensions.Logging.Abstractions;
    using ServerMonitor.Config;
    using ServerMonitor.Converters;
    using ServerMonitor.Tests.Mocks;

    internal class MessageConverterContext : BaseContext<MessageConverter>
    {
        private readonly IOptionsAppConfigMock ConfigMock;
        
        public MessageConverterContext()
        {
            this.ConfigMock = new IOptionsAppConfigMock();
            var logger = new NullLogger<MessageConverter>();

            this.Obj = new MessageConverter(this.ConfigMock.Object, logger);
        }

        public MessageConverterContext WithAppConfig(AppConfig appConfig)
        {
            this.ConfigMock.Mock_Config(appConfig);
            return this;
        }
    }
}
