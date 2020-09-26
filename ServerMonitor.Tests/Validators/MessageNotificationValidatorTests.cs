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
    internal class MessageNotificationValidatorTests : BaseTest<MessageNotificationValidator, MessageNotificationValidatorContext>
    {
        [Test]
        public void WhenMessageNotificationConfigProvided_ShouldThrowNothing()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.Nothing);
        }

        [Test]
        public void WhenNoMessageNotificationConfigProvided_ShouldThrowArgumentNullException()
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
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();

            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenDelayStartLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN - 1)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();

            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenDelayStartGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MAX + 1)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenNoDisplayProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoFromProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoRunIntervalProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenRunIntervalLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN - 1)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenRunIntervalGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MAX + 1)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();

            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenNoLimitProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenLimitLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN - 1)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenLimitGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MAX + 1)
                .WithMessageRecipients(new List<MessageRecipient>() { recipient })
                .Build();

            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenNoMessageRecipientsProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var recipient = new MessageRecipientBuilder()
                .WithAddress("address")
                .Build();

            var config = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithDelayStart(AppConsts.DELAY_MIN)
                .WithDisplay("display")
                .WithFrom("from")
                .WithRunInterval(AppConsts.INTERVAL_MIN)
                .WithLimit(AppConsts.MESSAGES_LIMIT_MIN)
                .Build();

            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(config), Throws.ArgumentNullException);
        }
    }
}
