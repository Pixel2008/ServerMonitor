namespace ServerMonitor.Tests.Converters
{
    using NUnit.Framework;
    using ServerMonitor.Config;
    using ServerMonitor.Converters;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestFixture]
    internal class MessageConverterTests : BaseTest<MessageConverter, MessageConverterContext>
    {        
        [Test]
        public async Task WhenMemoryMetricsWithAppConfigProvidedWithoutReportModeWithoutWarningWithoutTest_ShouldReturnNull()
        {
            //Arrange
            var memoryConfig = new MemoryConfigBuilder()
                .WithMaxPercentageUsage(90)
                .WithReportMode(false)
                .Build();

            var config = new AppConfigBuilder()
                .WithMemory(memoryConfig)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var memoryMetrics = new MemoryMetricsBuilder()
                .WithTotal(10)
                .WithFree(10)
                .Build();

            //Act
            var message = await converter.GetAsync(memoryMetrics);

            //Assert
            Assert.IsNull(message);
        }

        [Test]
        public async Task WhenMemoryMetricsWithAppConfigProvidedWithReportMode_ShouldReturnMessage()
        {
            //Arrange
            var memoryConfig = new MemoryConfigBuilder()
                .WithMaxPercentageUsage(90)
                .WithReportMode(true)
                .Build();

            var config = new AppConfigBuilder()
                .WithMemory(memoryConfig)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var memoryMetrics = new MemoryMetricsBuilder()
                .WithTotal(10)
                .WithFree(10)
                .Build();

            //Act
            var message = await converter.GetAsync(memoryMetrics);

            //Assert
            Assert.AreEqual("RAM Memory", message.Title);
            Assert.AreEqual("Total: 10B\r\nUsed: 0B\r\nFree: 10B", message.Content);
        }

        [Test]
        public async Task WhenMemoryMetricsWithAppConfigProvidedWithWarning_ShouldReturnMessage()
        {
            //Arrange
            var memoryConfig = new MemoryConfigBuilder()
                .WithMaxPercentageUsage(10)
                .Build();

            var config = new AppConfigBuilder()
                .WithMemory(memoryConfig)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var memoryMetrics = new MemoryMetricsBuilder()
                .WithTotal(100)
                .WithFree(30)
                .Build();

            //Act
            var message = await converter.GetAsync(memoryMetrics);

            //Assert
            Assert.AreEqual("Warning - RAM Memory", message.Title);
            Assert.AreEqual("RAM memory 70% consumed!\r\n\r\n\r\nTotal: 100B\r\nUsed: 70B\r\nFree: 30B", message.Content);
        }

        [Test]
        public async Task WhenMemoryMetricsWithAppConfigProvidedWithTest_ShouldReturnMessage()
        {
            //Arrange
            var memoryConfig = new MemoryConfigBuilder()
                .WithMaxPercentageUsage(80)
                .Build();

            var config = new AppConfigBuilder()
                .WithMemory(memoryConfig)
                .WithTest(true)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var memoryMetrics = new MemoryMetricsBuilder()
                .WithTotal(100)
                .WithFree(30)
                .Build();

            //Act
            var message = await converter.GetAsync(memoryMetrics);

            //Assert
            Assert.AreEqual("RAM Memory", message.Title);
            Assert.AreEqual("Total: 100B\r\nUsed: 70B\r\nFree: 30B", message.Content);
        }

        [Test]
        public async Task WhenDiskDriveMetricsWithAppConfigProvidedWithoutReportModeWithoutWarningWithoutTest_ShouldReturnNull()
        {
            //Arrange
            string path = @"c:\";
            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition()
                {
                     Path = path,
                     MaxPercentageUsage=10
                }
                })
                .WithReportMode(false)
                .Build();

            var config = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var diskDriveMetrics = new DiskDriveMetricsBuilder()
                .WithPath(path)
                .WithIsReady(true)
                .WithTotal(10)
                .WithFree(10)
                .Build();

            //Act
            var message = await converter.GetAsync(diskDriveMetrics);

            //Assert
            Assert.IsNull(message);
        }

        [Test]
        public async Task WhenDiskDriveMetricsWithAppConfigProvidedWithReportMode_ShouldReturnMessage()
        {
            //Arrange
            string path = @"c:\";
            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition()
                {
                     Path = path,
                     MaxPercentageUsage=10
                }
                })
                .WithReportMode(true)
                .Build();

            var config = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var diskDriveMetrics = new DiskDriveMetricsBuilder()
                .WithPath(path)
                .WithIsReady(true)
                .WithTotal(10)
                .WithFree(10)
                .Build();

            //Act
            var message = await converter.GetAsync(diskDriveMetrics);

            //Assert
            Assert.AreEqual($"DiskDrive - {path}", message.Title);
            Assert.AreEqual("Capacity: 10B\r\nFree space: 10B", message.Content);
        }

        [Test]
        public async Task WhenDiskDriveMetricsWithAppConfigProvidedWithWarning_ShouldReturnMessage()
        {
            //Arrange
            string path = @"c:\";
            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition()
                {
                     Path = path,
                     MaxPercentageUsage=10
                }
                })
                .Build();

            var config = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var diskDriveMetrics = new DiskDriveMetricsBuilder()
                .WithPath(path)
                .WithIsReady(true)
                .WithTotal(10)
                .WithFree(1)
                .Build();

            //Act
            var message = await converter.GetAsync(diskDriveMetrics);

            //Assert
            Assert.AreEqual($"Warning - DiskDrive - {path}", message.Title);
            Assert.AreEqual("Critical drive c:\\ 90% usage!\r\n\r\n\r\nCapacity: 10B\r\nFree space: 1B", message.Content);
        }

        [Test]
        public async Task WhenDiskDriveMetricsWithAppConfigProvidedWithTest_ShouldReturnMessage()
        {
            //Arrange
            string path = @"c:\";
            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition()
                {
                     Path = path,
                     MaxPercentageUsage=90
                }
                })
                .Build();

            var config = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .WithTest(true)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var diskDriveMetrics = new DiskDriveMetricsBuilder()
                .WithPath(path)
                .WithIsReady(true)
                .WithTotal(10)
                .WithFree(9)
                .Build();

            //Act
            var message = await converter.GetAsync(diskDriveMetrics);

            //Assert
            Assert.AreEqual($"DiskDrive - {path}", message.Title);
            Assert.AreEqual("Capacity: 10B\r\nFree space: 9B", message.Content);
        }

        [Test]
        public async Task WhenDiskDriveMetricsWithNotIsReadyWithAppConfigProvided_ShouldReturnMessage()
        {
            //Arrange
            string path = @"c:\";
            var diskDriveConfig = new DiskDriveConfigBuilder()
                .WithPartitions(new List<DiskDriveConfig.Partition>() { new DiskDriveConfig.Partition()
                {
                     Path = path,
                     MaxPercentageUsage=90
                }
                })
                .Build();

            var config = new AppConfigBuilder()
                .WithDiskDrive(diskDriveConfig)
                .WithTest(true)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var diskDriveMetrics = new DiskDriveMetricsBuilder()
                .WithPath(path)
                .WithIsReady(false)
                .WithTotal(10)
                .WithFree(9)
                .Build();

            //Act
            var message = await converter.GetAsync(diskDriveMetrics);

            //Assert
            Assert.AreEqual($"Warning - DiskDrive - {path}", message.Title);
            Assert.AreEqual("Drive c:\\ is not ready!", message.Content);
        }
    }
}
