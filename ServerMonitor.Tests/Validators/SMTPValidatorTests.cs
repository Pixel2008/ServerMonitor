namespace ServerMonitor.Tests.Validators
{
    using NUnit.Framework;
    using ServerMonitor.Consts;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using ServerMonitor.Validators;
    using System;

    [TestFixture]
    internal class SMTPValidatorTests : BaseTest<SMTPValidator, SMTPValidatorContext>
    {     
        [Test]
        public void WhenSMTPProvided_ShouldThrowNothing()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithPort(AppConsts.SMTP_PORT_MIN)
                .WithTimeout(AppConsts.SMTP_TIMEOUT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.Nothing);
        }

        [Test]
        public void WhenNoSMTPProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoServerProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithPort(AppConsts.SMTP_PORT_MIN)
                .WithTimeout(AppConsts.SMTP_TIMEOUT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenNoPortProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithTimeout(AppConsts.SMTP_TIMEOUT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void WhenPortLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithPort(AppConsts.SMTP_PORT_MIN - 1)
                .WithTimeout(AppConsts.SMTP_TIMEOUT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenPortGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithPort(AppConsts.SMTP_PORT_MAX + 1)
                .WithTimeout(AppConsts.SMTP_TIMEOUT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenNoTimeoutProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithPort(AppConsts.SMTP_PORT_MIN)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void WhenTimeoutLTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithPort(AppConsts.SMTP_PORT_MIN)
                .WithTimeout(AppConsts.SMTP_TIMEOUT_MIN - 1)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenTimeoutGTProvided_ShouldThrowArgumentNullException()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithPort(AppConsts.SMTP_PORT_MIN)
                .WithTimeout(AppConsts.SMTP_TIMEOUT_MAX + 1)
                .Build();
            var validator = this.Context.Build();

            //Act / Assert
            Assert.That(() => validator.ValidateAsync(smtp), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
