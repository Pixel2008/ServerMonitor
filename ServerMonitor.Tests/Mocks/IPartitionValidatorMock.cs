namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Config;
    using ServerMonitor.Validators;
    using System;
    using System.Linq.Expressions;

    internal class IPartitionValidatorMock : BaseMock<IPartitionValidator>
    {
        public void Mock_Validate()
        {
            this.Mock
                .Setup(x => x.Validate(It.IsAny<DiskDriveConfig.Partition>()));
        }

        public void Mock_Validate(Expression<Func<DiskDriveConfig.Partition, bool>> match)
        {
            this.Mock
                .Setup(x => x.Validate(It.Is(match)));
        }

        public void Verify_ValidateCalled(Times times)
        {
            this.Mock
                .Verify(x => x.Validate(It.IsAny<DiskDriveConfig.Partition>()), times);
        }

        public void Verify_ValidateCalled(Expression<Func<DiskDriveConfig.Partition, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.Validate(It.Is(match)), times);
        }
    }
}
