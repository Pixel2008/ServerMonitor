namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Config;
    using ServerMonitor.Validators;
    using System;
    using System.Linq.Expressions;

    internal class IMemoryConfigValidatorMock : BaseMock<IMemoryConfigValidator>
    {
        public void Mock_Validate()
        {
            this.Mock
                .Setup(x => x.ValidateAsync(It.IsAny<MemoryConfig>()));
        }

        public void Mock_Validate(Expression<Func<MemoryConfig, bool>> match)
        {
            this.Mock
                .Setup(x => x.ValidateAsync(It.Is(match)));
        }

        public void Verify_ValidateCalled(Times times)
        {
            this.Mock
                .Verify(x => x.ValidateAsync(It.IsAny<MemoryConfig>()), times);
        }

        public void Verify_ValidateCalled(Expression<Func<MemoryConfig, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.ValidateAsync(It.Is(match)), times);
        }
    }
}
