using MimeKit;
using ServerMonitor.Domain;

namespace ServerMonitor.Converters
{
    internal interface IMimeMessageConverter
    {
        MimeMessage Get(Message message);
    }
}
