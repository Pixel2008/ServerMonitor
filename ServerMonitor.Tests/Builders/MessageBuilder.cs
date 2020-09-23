namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Domain;

    internal class MessageBuilder : BaseBuilder<Message>
    {
        public MessageBuilder WithTitle(string title)
        {
            this.Obj.Title = title;
            return this;
        }
        public MessageBuilder WithContent(string content)
        {
            this.Obj.Content = content;
            return this;
        }
    }
}
