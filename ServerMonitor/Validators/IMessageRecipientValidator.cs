using ServerMonitor.Config;

namespace ServerMonitor.Validators
{
    internal interface IMessageRecipientValidator
    {
        void Validate(MessageRecipient messageRecipient);
    }
}