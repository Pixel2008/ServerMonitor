﻿namespace ServerMonitor.Tests.Mocks
{
    using Moq;
    using ServerMonitor.Components;
    using ServerMonitor.Domain;

    internal class IMemoryInfoMock : BaseMock<IMemoryInfo>
    {
        public void Mock_GetMemoryMetrics(MemoryMetrics response)
        {
            this.Mock
                .Setup(x => x.GetMemoryMetricsAsync())
                .ReturnsAsync(response);
        }

        public void Verify_GetMemoryMetricsCalled(Times times)
        {
            this.Mock
                .Verify(x => x.GetMemoryMetricsAsync(), times);
        }
    }
}
