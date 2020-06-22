using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ServerMonitor.Domain
{
    internal class Message
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string Debug => $"{GetType().Name}:" +
            $"{nameof(Title)}={Title}";
    }
}
