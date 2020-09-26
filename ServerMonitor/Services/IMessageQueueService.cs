namespace ServerMonitor.Services
{
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IMessageQueueService
    {
        Task EnqueueAsync(Message message);
        Task<Message> DequeueAsync();
    }
}
