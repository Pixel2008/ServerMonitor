using NUnit.Framework;
using ServerMonitor.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMonitor.Tests.Validators
{
    [TestFixture]
    internal class MessageRecipientValidatorTests
    {
        private MessageRecipientValidatorContext context;

        [SetUp]
        public void Setup()
        {
            this.context = new MessageRecipientValidatorContext();
        }

        [Test]
        public void WhenMessageRecipientProvided_ShouldThrowNothing()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(recipient), Throws.Nothing);
        }

        [Test]
        public void WhenNoMessageRecipientProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoAddressProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .Build();
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(recipient), Throws.ArgumentNullException);
        }

    }
}
