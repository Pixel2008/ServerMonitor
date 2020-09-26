namespace ServerMonitor.Services
{
    using Microsoft.Extensions.Logging;
    using ServerMonitor.Components;
    using ServerMonitor.Domain;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    internal class MessageQueueService : IMessageQueueService
    {
        #region Members
        private readonly IMessageDecorator messageDecorator;
        private readonly ILogger<MessageQueueService> logger;
        private readonly ConcurrentQueue<Message> messages;
        #endregion

        #region .ctor
        public MessageQueueService(IMessageDecorator messageDecorator, ILogger<MessageQueueService> logger)
        {
            this.messageDecorator = messageDecorator;
            this.logger = logger;
            this.messages = new ConcurrentQueue<Message>();
        }
        #endregion

        #region Methods
        public async Task EnqueueAsync(Message message)
        {
            this.logger.LogDebug($"Adding message to queue: {message.Debug}.");
            var msg = await this.messageDecorator.GetMessageAsync(message);
            this.messages.Enqueue(msg);
        }
        public Task<Message> DequeueAsync()
        {
            if (this.messages.TryDequeue(out Message message))
            {
                this.logger.LogDebug($"Removing mail from queue: {message.Debug}.");
                return Task.FromResult(message);
            }
            return Task.FromResult<Message>(null);
        }
        #endregion
    }
}
