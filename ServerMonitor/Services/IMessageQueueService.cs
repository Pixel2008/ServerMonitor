namespace ServerMonitor.Services
{
    using ServerMonitor.Domain;

    internal interface IMessageQueueService
    {
        void Enqueue(Message message);
        Message Dequeue();
    }
}
