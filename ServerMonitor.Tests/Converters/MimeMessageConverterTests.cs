namespace ServerMonitor.Tests.Converters
{
    using MimeKit;
    using NUnit.Framework;
    using ServerMonitor.Config;
    using ServerMonitor.Converters;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    internal class MimeMessageConverterTests : BaseTest<MimeMessageConverter, MimeMessageConverterContext>
    {
        [Test]
        public void WhenMessageWithAppConfigProvided_ShouldReturnMimeMessage()
        {
            //Arrange
            var title = "title";
            var content = "content";
            var from = "from@mail.pl";
            var display = "FromDisplay";
            var to = "to@mail.pl";

            var messageNotificationConfig = new MessageNotificationConfigBuilder()
                .WithFrom(from)
                .WithDisplay(display)
                .WithMessageRecipients(new List<MessageRecipient>() {
                        new MessageRecipient{ Address = to } })
                .Build();            

            var config = new AppConfigBuilder()
                .WithMessageNotification(messageNotificationConfig)
                .Build();

            var converter = this.Context
                .WithAppConfig(config)
                .Build();

            var message = new MessageBuilder()
                .WithTitle(title)
                .WithContent(content)
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
