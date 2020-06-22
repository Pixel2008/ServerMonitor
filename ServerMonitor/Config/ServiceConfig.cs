using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Config
{
    internal class ServiceConfig
    {
        public bool Enabled { get; set; }        
        public int RunInterval { get; set; }
        public int DelayStart { get; set; }

        public string Debug => $"{GetType().Name}:" +
            $"{nameof(Enabled)}={Enabled}," +
            $"{nameof(RunInterval)}={RunInterval}seconds," +
            $"{nameof(DelayStart)}={DelayStart}seconds";
    }
}
