using Moq;
using ServerMonitor.Config;
using ServerMonitor.Validators;

namespace ServerMonitor.Tests.Validators
{
    internal class DiskDriveConfigValidatorContext
    {
        private readonly DiskDriveConfigValidator obj;

        public DiskDriveConfigValidatorContext()
        {
            var partitionValidatorMock = new Mock<IPartitionValidator>();
            partitionValidatorMock.Setup(x => x.Validate(It.IsAny<DiskDriveConfig.Partition>()));
            this.obj = new DiskDriveConfigValidator(partitionValidatorMock.Object);
        }

        public DiskDriveConfigValidator Build()
        {
            return this.obj;
        }
    }
}
