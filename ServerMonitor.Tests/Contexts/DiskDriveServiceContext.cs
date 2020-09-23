namespace ServerMonitor.Tests.Contexts
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Mocks;

    internal class DiskDriveServiceContext : BaseContext<DiskDriveService>
    {
        public readonly IOptionsAppConfigMock ConfigMock;
        public readonly IDiskDriveConfigValidatorMock DiskDriveConfigValidatorMock;
        public readonly IMessageConverterMock MessageConverterMock;
        public readonly IDiskDriveInfoMock DiskDriveInfoMock;
        public readonly IMessageQueueServiceMock MessageQueueServiceMock;

        public DiskDriveServiceContext()
        {
            this.ConfigMock = new IOptionsAppConfigMock();
            this.DiskDriveConfigValidatorMock = new IDiskDriveConfigValidatorMock();
            this.MessageConverterMock = new IMessageConverterMock();
            this.DiskDriveInfoMock = new IDiskDriveInfoMock();
            this.MessageQueueServiceMock = new IMessageQueueServiceMock();

            var loggerMock = new Mock<ILogger<DiskDriveService>>();

            this.Obj = new DiskDriveService(this.ConfigMock.Object,
                this.DiskDriveConfigValidatorMock.Object,
                this.MessageConverterMock.Object,
                this.DiskDriveInfoMock.Object,
                this.MessageQueueServiceMock.Object,
                loggerMock.Object);
        }                     
       
    }
}
