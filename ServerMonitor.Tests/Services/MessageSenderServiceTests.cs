namespace ServerMonitor.Tests.Services
{
    using Moq;
    using NUnit.Framework;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using System.Threading.Tasks;

    [TestFixture]
    internal class MessageSenderServiceTests : BaseTest<MessageSenderService, MessageSenderServiceContext>
    {
        [Test]
        public async Task ValidationShouldBeExecutedOnce()
        {
            //Arrange            
            var from = "from";
            var limit = 5;
            var display = "display";
            var messageNotification = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithFrom(from)
                .WithLimit(limit)
                .WithDisplay(display)
                .Build();

            var appConfig = new AppConfigBuilder()
                .WithMessageNotification(messageNotification)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);

            var service = this.Context.Build();

            //Act
            await service.ValidateAsync();

            //Assert
            this.Context.MessageNotificationValidatorMock.Verify_ValidateCalled(x => x.Enabled == true && x.From == from && x.Limit == limit && x.Display == display, Times.Once());
        }

        [Test]
        public async Task WhenNoMessages_ShouldNotSend()
        {
            //Arrange            
            var from = "from";
            var limit = 5;
            var display = "display";
            var messageNotification = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithFrom(from)
                .WithLimit(limit)
                .WithDisplay(display)
                .Build();

            var appConfig = new AppConfigBuilder()
                .WithMessageNotification(messageNotification)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);
            this.Context.MessageQueueServiceMock.Mock_Dequeue(null);

            var service = this.Context.Build();

            //Act
            await service.DoWorkAsync();

            //Assert
            this.Context.MessageQueueServiceMock.Verify_DequeueCalled(Times.Once());
            this.Context.MessageSenderMock.Veirfy_SendMessageCalled(Times.Never());
        }

        [Test]
        public async Task WhenMessages_ShouldSend()
        {
            //Arrange   
            string title = "title";
            string content = "content";

            var from = "from";
            var limit = 5;
            var display = "display";
            var messageNotification = new MessageNotificationConfigBuilder()
                .WithEnabled(true)
                .WithFrom(from)
                .WithLimit(limit)
                .WithDisplay(display)
                .Build();

            var appConfig = new AppConfigBuilder()
                .WithMessageNotification(messageNotification)
                .Build();

            this.Context.ConfigMock.Mock_Config(appConfig);
            var message = new MessageBuilder()
                .WithTitle(title)
                .WithContent(content)
                .Build();
            this.Context.MessageQueueServiceMock.Mock_Dequeue(message);

            var service = this.Context.Build();

            //Act
            await service.DoWorkAsync();

            //Assert
            this.Context.MessageQueueServiceMock.Verify_DequeueCalled(Times.Exactly(limit));
            this.Context.MessageSenderMock.Verify_SendMessageCalled(x => x.Title == title && x.Content == content, Times.Exactly(limit));
        }
    }
}
