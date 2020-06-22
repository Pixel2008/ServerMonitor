using ServerMonitor.Domain;

namespace ServerMonitor.Components
{
    internal interface IMessageSender
    {
        void SendMessage(Message mail);
    }
}
