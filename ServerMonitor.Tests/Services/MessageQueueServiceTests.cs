namespace ServerMonitor.Tests.Services
{
    using Moq;
    using NUnit.Framework;
    using ServerMonitor.Services;
    using ServerMonitor.Tests.Builders;
    using ServerMonitor.Tests.Contexts;

    [TestFixture]
    internal class MessageQueueServiceTests : BaseTest<MessageQueueService, MessageQueueServiceContext>
    {
        [Test]
        public void WhenEnqueue_ShouldEnqueueMessage()
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
            service.Enqueue(expected);

            //Assert
            var actualMessage = service.Dequeue();
            Assert.AreEqual(expected.Title, actualMessage.Title);
            Assert.AreEqual(expected.Content, actualMessage.Content);
        }

        [Test]
        public void WhenDequeueWithNoMessages_ShouldReturnNull()
        {
            //Arrange
            var service = this.Context.Build();

            //Act
            var expected = service.Dequeue();

            //Assert
            Assert.IsNull(expected);
        }
    }
}
