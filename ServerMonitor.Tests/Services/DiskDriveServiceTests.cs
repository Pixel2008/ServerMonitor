namespace ServerMonitor.Tests.Services
{
    using Moq;
    using NUnit.Framework;
    using ServerMonitor.Config;
    using ServerMonitor.Domain;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [TestFixture]
    internal class DiskDriveServiceTests : BaseTest<DiskDriveService, DiskDriveServiceContext>
    {
        [Test]
        public async Task ValidationShouldBeExecutedOnce()
        {
            //Arrange
            var path = @"c:\";
            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition() { Path = path } })
                .Build();
            var appConfig = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);

            var service = this.Context.Build();

            //Act
            await service.ValidateAsync();

            //Assert
            this.Context.DiskDriveConfigValidatorMock.Verify_ValidateCalled(x => x.Enabled == true && x.Partitions.First().Path == path, Times.Once());
        }

        [Test]
        public async Task WhenNoPartitionsProvided_ShouldRunWithoutDoingAnything()
        {
            //Arrange
            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { })
                .Build();
            var appConfig = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);

            var service = this.Context.Build();

            //Act
            await service.DoWorkAsync();

            //Assert
            this.Context.DiskDriveInfoMock.Verify_GetDiskDriveMetricsCalled(Times.Never());
            this.Context.MessageConverterMock.Verify_GetCalledForDiskDriveMetrics(Times.Never());
            this.Context.MessageQueueServiceMock.Verify_EnqueueCalled(Times.Never());
        }

        [Test]
        public async Task WhenPartitionProvidedAndNoMessageReturn_ShouldNotQueueMessage()
        {
            //Arrange
            var total = 100;
            var free = 50;
            var path = @"c:\";
            var maxPercentageUsage = 10;

            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition() { Path = path, MaxPercentageUsage = maxPercentageUsage } })
                .Build();

            var appConfig = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .Build();
            this.Context.ConfigMock.Mock_Config(appConfig);

            var metrics = new DiskDriveMetricsBuilder()
                .WithPath(path)
                .WithTotal(total)
                .WithFree(free)
                .Build();
            this.Context.DiskDriveInfoMock.Mock_GetDiskDriveMetrics(metrics);

            this.Context.MessageConverterMock.Mock_Get((Expression<Func<DiskDriveMetrics, bool>>)(x => x.Path == path && x.Total == total && x.Free == free), null);

            var service = this.Context.Build();

            //Act
            await service.DoWorkAsync();

            //Assert
            this.Context.DiskDriveInfoMock.Verify_GetDiskDriveMetricsCalled(x => x.Path == path && x.MaxPercentageUsage == maxPercentageUsage, Times.Once());
            this.Context.MessageConverterMock.Verify_GetCalled(x => x.Path == path && x.Total == total && x.Free == free, Times.Once());
            this.Context.MessageQueueServiceMock.Verify_EnqueueCalled(Times.Never());
        }

        [Test]
        public async Task WhenPartitionProvided_ShouldQueueMessage()
        {
            //Arrange
            var total = 100;
            var free = 50;
            var path = @"c:\";
            var maxPercentageUsage = 10;
            var title = "title";
            var content = "content";

            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition() { Path = path, MaxPercentageUsage = maxPercentageUsage } })
                .Build();

            var appConfig = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .Build();
            this.Context.ConfigMock.Mock_Config(appConfig);

            var metrics = new DiskDriveMetricsBuilder()
                .WithPath(path)
                .WithTotal(total)
                .WithFree(free)
                .Build();
            this.Context.DiskDriveInfoMock.Mock_GetDiskDriveMetrics(metrics);

            var message = new MessageBuilder()
                .WithTitle(title)
                .WithContent(content)
                .Build();
            this.Context.MessageConverterMock.Mock_Get((Expression<Func<DiskDriveMetrics, bool>>)(x => x.Path == path && x.Total == total && x.Free == free), message);

            var service = this.Context.Build();

            //Act
            await service.DoWorkAsync();

            //Assert
            this.Context.DiskDriveInfoMock.Verify_GetDiskDriveMetricsCalled(x => x.Path == path && x.MaxPercentageUsage == maxPercentageUsage, Times.Once());
            this.Context.MessageConverterMock.Verify_GetCalled(x => x.Path == path && x.Total == total && x.Free == free, Times.Once());
            this.Context.MessageQueueServiceMock.Verify_EnqueueCalled(x => x.Title == title && x.Content == content, Times.Once());
        }
    }
}
