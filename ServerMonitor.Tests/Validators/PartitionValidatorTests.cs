namespace ServerMonitor.Tests.Validators
{
    using NUnit.Framework;
    using ServerMonitor.Consts;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using ServerMonitor.Validators;

    [TestFixture]
    internal class PartitionValidatorTests : BaseTest<PartitionValidator, PartitionValidatorContext>
    {        
        [Test]
        public void WhenPartitionProvided_ShouldThrowNothing()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(partition), Throws.Nothing);
        }

        [Test]
        public void WhenNoPartitionProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoPathProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoMinPercentageUsageProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenMinPercentageUsageLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MIN - 1)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenMinPercentageUsageGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var partition = new PartitionBuilder()
                .WithPath("path")
                .WithMinPercentageUsage(AppConsts.PERCENT_MAX + 1)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }
    }
}
