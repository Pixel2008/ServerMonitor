namespace ServerMonitor.Tests.Validators
{
    using NUnit.Framework;
    using ServerMonitor.Config;
    using ServerMonitor.Consts;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using ServerMonitor.Validators;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    internal class DiskDriveConfigValidatorTests : BaseTest<DiskDriveConfigValidator, DiskDriveConfigValidatorContext>
    {
        [Test]
        public void WhenDiskDriveConfigProvided_ShouldThrowNothing()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();

            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { partition })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.Nothing);
        }

        [Test]
        public void WhenNoDiskDriveConfigProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoDelayStartProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();

            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { partition })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenDelayStartLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();

            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN - 1)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { partition })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenDelayStartGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();

            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MAX + 1)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { partition })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenNoPartitionsProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoRunIntervalProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();

            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithReportMode(true)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { partition })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenRunIntervalLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();

            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN - 1)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { partition })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenRunIntervalGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();

            var config = new DiskDriveConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MAX + 1)
                .WithPartitions(new List<DiskDriveConfig.Partition>() { partition })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
