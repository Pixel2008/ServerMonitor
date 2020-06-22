using NUnit.Framework;
using ServerMonitor.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMonitor.Tests.Validators
{
    [TestFixture]
    internal class MessageValidatorTests
    {
        private MessageValidatorContext context;

        [SetUp]
        public void Setup()
        {
            this.context = new MessageValidatorContext();
        }

        [Test]
        public void WhenMessage_ShouldThrowNothing()
        {
            //Arrange
            var message = new MessageBuilder()
                .WithTitle("title")
                .WithContent("content")
                .Build();
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(message), Throws.Nothing);
        }

        [Test]
        public void WhenNoMessage_ShouldThrowArgumentNullException()
        {
            //Arrange
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenMessageWithTitle_ShouldThrowArgumentNullException()
        {
            //Arrange
            var message = new MessageBuilder()
                .WithTitle("title")
                .Build();
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(message), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenMessageWithContent_ShouldThrowArgumentNullException()
        {
            //Arrange
            var message = new MessageBuilder()
                .WithContent("content")
                .Build();
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(message), Throws.ArgumentNullException);
        }
    }
}
