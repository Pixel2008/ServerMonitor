namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Components;
    using ServerMonitor.Config;
    using ServerMonitor.Domain;
    using System;
    using System.Linq.Expressions;

    internal class IDiskDriveInfoMock : BaseMock<IDiskDriveInfo>
    {
        public void Mock_GetDiskDriveMetrics(Expression<Func<DiskDriveConfig.Partition, bool>> match, DiskDriveMetrics response)
        {
            this.Mock
                .Setup(x => x.GetDiskDriveMetrics(It.Is(match)))
                .Returns(response);
        }

        public void Mock_GetDiskDriveMetrics(DiskDriveMetrics response)
        {
            this.Mock
                .Setup(x => x.GetDiskDriveMetrics(It.IsAny<DiskDriveConfig.Partition>()))
                .Returns(response);
        }
        public void Verify_GetDiskDriveMetricsCalled(Expression<Func<DiskDriveConfig.Partition, bool>> match, Times times)
        {
            this.Mock
                .Verify(x => x.GetDiskDriveMetrics(It.Is(match)), times);
        }
        public void Verify_GetDiskDriveMetricsCalled(Times times)
        {
            this.Mock
                .Verify(x => x.GetDiskDriveMetrics(It.IsAny<DiskDriveConfig.Partition>()), times);
        }
    }
}
