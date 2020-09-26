namespace ServerMonitor.Converters
{
    using MimeKit;
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IMimeMessageConverter
    {
        Task<MimeMessage> GetAsync(Message message);
    }
}
