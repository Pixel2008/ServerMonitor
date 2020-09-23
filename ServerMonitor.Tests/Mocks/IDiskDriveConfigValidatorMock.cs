namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Config;
    using ServerMonitor.Validators;
    using System;
    using System.Linq.Expressions;

    internal class IDiskDriveConfigValidatorMock : BaseMock<IDiskDriveConfigValidator>
    {                       
        public void Mock_Validate(DiskDriveConfig config)
        {
            this.Mock
                .Setup(x => x.Validate(config));
        }
        public void Verify_ValidateCalled(Expression<Func<DiskDriveConfig, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.Validate(It.Is(match)), times);
        }      
    }
}
