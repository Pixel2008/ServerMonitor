namespace ServerMonitor.Validators
{
    using ServerMonitor.Config;
    using System;
    using System.Threading.Tasks;

    internal class MessageRecipientValidator : IMessageRecipientValidator
    {
        public Task ValidateAsync(MessageRecipient messageRecipient)
        {
            if (messageRecipient == null)
            {
                throw new ArgumentNullException(nameof(messageRecipient));
            }
            if(string.IsNullOrWhiteSpace(messageRecipient.Address))
            {
                throw new ArgumentNullException(nameof(messageRecipient.Address));
            }
            return Task.CompletedTask;
        }
    }
}
