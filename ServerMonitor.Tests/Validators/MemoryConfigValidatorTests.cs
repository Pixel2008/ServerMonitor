﻿namespace ServerMonitor.Tests.Validators
{
    using NUnit.Framework;
    using ServerMonitor.Consts;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using ServerMonitor.Validators;
    using System;

    [TestFixture]
    internal class MemoryConfigValidatorTests : BaseTest<MemoryConfigValidator, MemoryConfigValidatorContext>
    {
        [Test]
        public void WhenMemoryConfigProvided_ShouldThrowNothing()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.Nothing);
        }

        [Test]
        public void WhenNoMemoryConfigProvided_ShouldThrowArgumentNullException()
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
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenDelayStartLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN - 1)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenDelayStartGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MAX + 1)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenNoMaxPercentageUsageProvided_ShouldThrowNothing()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.Nothing);
        }

        [Test]
        public void WhenMaxPercentageUsageLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN - 1)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenMaxPercentageUsageGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MAX + 1)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenNoRunIntervalProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN)
                .WithReportMode(true)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenRunIntervalLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MIN - 1)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenRunIntervalGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var config = new MemoryConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithMaxPercentageUsage(AppConsts.PERCENT_MIN)
                .WithReportMode(true)
                .WithRunInterval(AppConsts.INTERVAL_MAX + 1)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
