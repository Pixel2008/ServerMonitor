namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Converters;
    using ServerMonitor.Domain;
    using System;
    using System.Linq.Expressions;

    internal class IMessageConverterMock : BaseMock<IMessageConverter>
    {
        public void Mock_Get(Expression<Func<DiskDriveMetrics, bool>> match, Message response)
        {
            this.Mock
                .Setup(x => x.Get(It.Is(match)))
                .Returns(response);
        }

        public void Mock_Get(Expression<Func<MemoryMetrics, bool>> match, Message response)
        {
            this.Mock
                .Setup(x => x.Get(It.Is(match)))
                .Returns(response);
        }

        public void Verify_GetCalled(Expression<Func<DiskDriveMetrics, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.Get(It.Is(match)), times);
        }

        public void Verify_GetCalledForDiskDriveMetrics(Times times)
        {
            this.Mock
                .Verify(x => x.Get(It.IsAny<DiskDriveMetrics>()), times);
        }

        public void Verify_GetCalled(Expression<Func<MemoryMetrics, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.Get(It.Is(match)), times);
        }

        public void Verify_GetCalledForMemoryMetrics(Times times)
        {
            this.Mock
                .Verify(x => x.Get(It.IsAny<MemoryMetrics>()), times);
        }
    }
}
