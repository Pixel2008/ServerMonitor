using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Config
{
    internal class MessageNotificationConfig : ServiceConfig
    {
        public string From { get; set; }
        public string Display { get; set; }
        public int Limit { get; set; }
        public IList<MessageRecipient> MessageRecipients { get; set; }
    }
}
