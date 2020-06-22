using MimeKit;
using NUnit.Framework;
using ServerMonitor.Config;
using System.Collections.Generic;
using System.Linq;

namespace ServerMonitor.Tests.Builders
{
    [TestFixture]
    internal class MimeMessageConverterTests
    {
        private MimeMessageConverterContext context;

        [SetUp]
        public void Setup()
        {
            this.context = new MimeMessageConverterContext();
        }
        [Test]
        public void WhenMessageWithAppConfigProvided_ShouldReturnMimeMessage()
        {
            //Arrange
            var title = "title";
            var content = "content";
            var from = "from@mail.pl";
            var display = "FromDisplay";
            var to = "to@mail.pl";


            var message = new MessageBuilder()
                .WithTitle(title)
                .WithContent(content)
                .Build();

            var config = new AppConfigBuilder()
                .WithMessageNotification(new Config.MessageNotificationConfig
                {
                    From = from,
                    Display = display,
                    MessageRecipients = new List<MessageRecipient>() {
                        new MessageRecipient{ Address = to } }
                })
                .Build();

            var converter = this.context
                .WithAppConfig(config)
                .Build();

            //Act
            var mimeMessage = converter.Get(message);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(title, mimeMessage.Subject);
                Assert.AreEqual(content, mimeMessage.TextBody);
                Assert.AreEqual(from, (mimeMessage.From.First() as MailboxAddress).Address);
                Assert.AreEqual(display, (mimeMessage.From.First() as MailboxAddress).Name);
                Assert.AreEqual(to, (mimeMessage.To.First() as MailboxAddress).Address);
            });
        }
    }
}
