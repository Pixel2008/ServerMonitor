namespace ServerMonitor.Components
{
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IMessageDecorator
    {
        Task<Message> GetMessageAsync(Message message); 
    }
}
