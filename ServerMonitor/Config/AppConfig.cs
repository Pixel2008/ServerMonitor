using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Config
{
    internal class AppConfig
    {
        public bool Test { get; set; }
        public SMTP SMTP { get; set; }
        public MessageNotificationConfig MessageNotification { get; set; }
        public DiskDriveConfig DiskDrive { get; set; }
        public MemoryConfig Memory { get; set; }
                
    }
}
