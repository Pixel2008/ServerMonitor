namespace ServerMonitor.Tests.Services
{
    using Moq;
    using NUnit.Framework;
    using ServerMonitor.Domain;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using System;
    using System.Linq.Expressions;

    [TestFixture]
    internal class MemoryServiceTests : BaseTest<MemoryService, MemoryServiceContext>
    {
        [Test]
        public void ValidationShouldBeExecutedOnce()
        {
            //Arrange
            var maxPercentageUsage = 30;
            var memoryConfig = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithMaxPercentageUsage(maxPercentageUsage)
                .Build();
            var appConfig = new AppConfigBuilder()
                .WithMemory(memoryConfig)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);

            var service = this.Context.Build();

            //Act
            service.Validate();

            //Assert
            this.Context.MemoryConfigValidatorMock.Verify_ValidateCalled(x => x.Enabled == true && x.MaxPercentageUsage == maxPercentageUsage, Times.Once());
        }

        [Test]
        public void WhenNoMessageReturned_ShouldNotEnqueue()
        {
            //Arrange
            var maxPercentageUsage = 30;
            var total = 100;
            var free = 30;
            var memoryConfig = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithMaxPercentageUsage(maxPercentageUsage)
                .Build();
            var appConfig = new AppConfigBuilder()
                .WithMemory(memoryConfig)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);

            var memoryMetrics = new MemoryMetricsBuilder()
                .WithTotal(total)
                .WithFree(free)
                .Build();
            this.Context.MemoryInfoMock.Mock_GetMemoryMetrics(memoryMetrics);

            this.Context.MessageConverterMock.Mock_Get((Expression<Func<MemoryMetrics, bool>>)(x => x.Total == total && x.Free == free), null);

            var service = this.Context.Build();

            //Act
            service.DoWork();

            //Assert            
            this.Context.MemoryInfoMock.Verify_GetMemoryMetricsCalled(Times.Once());
            this.Context.MessageConverterMock.Verify_GetCalled((Expression<Func<MemoryMetrics, bool>>)(x => x.Total == total && x.Free == free), Times.Once());
            this.Context.MessageQueueServiceMock.Verify_EnqueueCalled(Times.Never());
        }

        [Test]
        public void WhenMessageReturned_ShouldEnqueue()
        {
            //Arrange
            var maxPercentageUsage = 30;
            var total = 100;
            var free = 30;
            var memoryConfig = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithMaxPercentageUsage(maxPercentageUsage)
                .Build();
            var appConfig = new AppConfigBuilder()
                .WithMemory(memoryConfig)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);

            var memoryMetrics = new MemoryMetricsBuilder()
                .WithTotal(total)
                .WithFree(free)
                .Build();
            this.Context.MemoryInfoMock.Mock_GetMemoryMetrics(memoryMetrics);

            var title = "title";
            var content = "content";
            var message = new MessageBuilder()
                .WithTitle(title)
                .WithContent(content)
                .Build();

            this.Context.MessageConverterMock.Mock_Get((Expression<Func<MemoryMetrics, bool>>)(x => x.Total == total && x.Free == free), message);

            var service = this.Context.Build();

            //Act
            service.DoWork();

            //Assert            
            this.Context.MemoryInfoMock.Verify_GetMemoryMetricsCalled(Times.Once());
            this.Context.MessageConverterMock.Verify_GetCalled((Expression<Func<MemoryMetrics, bool>>)(x => x.Total == total && x.Free == free), Times.Once());
            this.Context.MessageQueueServiceMock.Verify_EnqueueCalled(x => x.Title == title && x.Content == content, Times.Once());
        }
    }
}
