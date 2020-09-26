namespace ServerMonitor.Components
{
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IMessageSender
    {
        Task SendMessageAsync(Message mail);
    }
}
