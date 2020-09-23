namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Config;

    internal class MessageRecipientBuilder : BaseBuilder<MessageRecipient>
    {
        public MessageRecipientBuilder WithAddress(string address)
        {
            this.Obj.Address = address;
            return this;
        }
    }
}
