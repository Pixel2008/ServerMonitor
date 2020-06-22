using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Config
{
    internal class MessageRecipient
    {
        public string Address { get; set; }
    }
}
