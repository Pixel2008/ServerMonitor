using NUnit.Framework;
using ServerMonitor.Tests.Builders;

namespace ServerMonitor.Tests.Validators
{
    [TestFixture]
    internal class SMTPValidatorTests
    {
        private SMTPValidatorContext context;

        [SetUp]
        public void Setup()
        {
            this.context = new SMTPValidatorContext();
        }

        [Test]
        public void WhenSMTPProvided_ShouldThrowNothing()
        {
            //Arrange
            var smtp = new SMTPBuilder()
                .WithServer("server")
                .WithPort(1234)
                .WithTimeout(20)
                .Build();
            var validator = this.context.Build();

            //Act / Assert
            Assert.That(() => validator.Validate(smtp), Throws.Nothing);
        }



    }
}
