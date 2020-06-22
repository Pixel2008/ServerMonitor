using ServerMonitor.Domain;

namespace ServerMonitor.Tests.Builders
{
    internal class MessageBuilder
    {
        private readonly Message message;

        public MessageBuilder()
        {
            this.message = new Message();
        }
        public MessageBuilder WithTitle(string title)
        {
            this.message.Title = title;
            return this;
        }
        public MessageBuilder WithContent(string content)
        {
            this.message.Content = content;
            return this;
        }
        public Message Build()
        {
            return this.message;
        }
    }
}
