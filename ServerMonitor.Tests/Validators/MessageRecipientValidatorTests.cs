namespace ServerMonitor.Tests.Validators
{
    using NUnit.Framework;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using ServerMonitor.Validators;

    [TestFixture]
    internal class MessageRecipientValidatorTests : BaseTest<MessageRecipientValidator, MessageRecipientValidatorContext>
    {     

        [Test]
        public void WhenMessageRecipientProvided_ShouldThrowNothing()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(recipient), Throws.Nothing);
        }

        [Test]
        public void WhenNoMessageRecipientProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoAddressProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(recipient), Throws.ArgumentNullException);
        }
    }
}
