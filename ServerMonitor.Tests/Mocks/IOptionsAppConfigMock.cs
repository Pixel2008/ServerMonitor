namespace ServerMonitor.Tests.Mocks
{
    using Microsoft.Extensions.Options;
    using ServerMonitor.Config;

    internal class IOptionsAppConfigMock : BaseMock<IOptions<AppConfig>>
    {        
        public void Mock_Config(AppConfig config)
        {
            this.Mock
                .Setup(x => x.Value)
                .Returns(config);
        }
    }
}
