using ServerMonitor.Config;
using System;

namespace ServerMonitor.Validators
{
    internal class MessageRecipientValidator : IMessageRecipientValidator
    {
        public void Validate(MessageRecipient messageRecipient)
        {
            if (messageRecipient == null)
            {
                throw new ArgumentNullException(nameof(messageRecipient));
            }
            if(string.IsNullOrWhiteSpace(messageRecipient.Address))
            {
                throw new ArgumentNullException(nameof(messageRecipient.Address));
            }
        }
    }
}
