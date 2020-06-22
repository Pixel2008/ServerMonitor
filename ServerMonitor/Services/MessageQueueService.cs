using Microsoft.Extensions.Logging;
using ServerMonitor.Components;
using ServerMonitor.Domain;
using System.Collections.Concurrent;

namespace ServerMonitor.Services
{
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
        public void Enqueue(Message message)
        {
            this.logger.LogDebug($"Adding message to queue: {message.Debug}.");
            var msg = this.messageDecorator.GetMessage(message);
            this.messages.Enqueue(msg);
        }
        public Message Dequeue()
        {
            if (this.messages.TryDequeue(out Message message))
            {
                this.logger.LogDebug($"Removing mail from queue: {message.Debug}.");
                return message;
            }
            return null;
        }
        #endregion
    }
}
