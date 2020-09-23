namespace ServerMonitor.Tests.Validators
{
    using NUnit.Framework;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using ServerMonitor.Validators;

    [TestFixture]
    internal class MessageValidatorTests : BaseTest<MessageValidator, MessageValidatorContext>
    {      
        [Test]
        public void WhenMessageProvided_ShouldThrowNothing()
        {
            //Arrange
            var message = new MessageBuilder()
                .WithTitle("title")
                .WithContent("content")
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(message), Throws.Nothing);
        }

        [Test]
        public void WhenNoMessageProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoContentProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var message = new MessageBuilder()
                .WithTitle("title")
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(message), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoTitleProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var message = new MessageBuilder()
                .WithContent("content")
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(message), Throws.ArgumentNullException);
        }
    }
}
