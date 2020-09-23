namespace ServerMonitor.Tests.Contexts
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Mocks;

    internal class MemoryServiceContext : BaseContext<MemoryService>
    {
        public readonly IOptionsAppConfigMock ConfigMock;
        public readonly IMemoryConfigValidatorMock MemoryConfigValidatorMock;
        public readonly IMessageConverterMock MessageConverterMock;
        public readonly IMemoryInfoMock MemoryInfoMock;
        public readonly IMessageQueueServiceMock MessageQueueServiceMock;

        public MemoryServiceContext()
        {
            this.ConfigMock = new IOptionsAppConfigMock();
            this.MemoryConfigValidatorMock = new IMemoryConfigValidatorMock();
            this.MessageConverterMock = new IMessageConverterMock();
            this.MemoryInfoMock = new IMemoryInfoMock();
            this.MessageQueueServiceMock = new IMessageQueueServiceMock();

            var loggerMock = new Mock<ILogger<MemoryService>>();

            this.Obj = new MemoryService(this.ConfigMock.Object,
                this.MemoryConfigValidatorMock.Object,
                this.MessageConverterMock.Object,
                this.MemoryInfoMock.Object,
                this.MessageQueueServiceMock.Object,
                loggerMock.Object);
        }                     
       
    }
}
