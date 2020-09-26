namespace ServerMonitor.Validators
{
    using ServerMonitor.Config;
    using System.Threading.Tasks;

    internal interface IMessageRecipientValidator
    {
        Task ValidateAsync(MessageRecipient messageRecipient);
    }
}