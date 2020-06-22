using ServerMonitor.Domain;

namespace ServerMonitor.Components
{
    internal interface IMessageDecorator
    {
        Message GetMessage(Message message); 
    }
}
