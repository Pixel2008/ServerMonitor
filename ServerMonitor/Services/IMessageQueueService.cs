using ServerMonitor.Domain;

namespace ServerMonitor.Services
{
    internal interface IMessageQueueService
    {
        void Enqueue(Message message);
        Message Dequeue();
    }
}
