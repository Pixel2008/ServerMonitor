using ServerMonitor.Config;

namespace ServerMonitor.Tests.Builders
{
    internal class MessageRecipientBuilder
    {
        private readonly MessageRecipient recipient;

        public MessageRecipientBuilder()
        {
            this.recipient = new MessageRecipient();
        }
        public MessageRecipientBuilder WithAddress(string address)
        {
            this.recipient.Address = address;
            return this;
        }

        public MessageRecipient Build()
        {
            return this.recipient;
        }
    }
}
