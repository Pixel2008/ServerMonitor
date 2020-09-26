namespace ServerMonitor.Tests.Services
{
    using Moq;
    using NUnit.Framework;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;
    using System.Threading.Tasks;

    [TestFixture]
    internal class MessageQueueServiceTests : BaseTest<MessageQueueService, MessageQueueServiceContext>
    {
        [Test]
        public async Task WhenEnqueue_ShouldEnqueueMessage()
        {
            //Arrange
            string title = "title";
            string content = "content";

            var response = new MessageBuilder()
                 .WithTitle(title)
                 .WithContent(content)
                 .Build();
            this.Context.MessageDecoratorMock.Mock_GetMessage(response);

            var expected = new MessageBuilder()
                .WithTitle(title)
                .WithContent(content)
                .Build();
            var service = this.Context.Build();

            //Act
            await service.EnqueueAsync(expected);

            //Assert
            var actualMessage = await service.DequeueAsync();
            Assert.AreEqual(expected.Title, actualMessage.Title);
            Assert.AreEqual(expected.Content, actualMessage.Content);
        }

        [Test]
        public async Task WhenDequeueWithNoMessages_ShouldReturnNull()
        {
            //Arrange
            var service = this.Context.Build();

            //Act
            var expected = await service.DequeueAsync();

            //Assert
            Assert.IsNull(expected);
        }
    }
}
