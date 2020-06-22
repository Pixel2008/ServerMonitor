using ServerMonitor.Extensions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Domain
{
    internal class DiskDriveMetrics
    {
        public string Path { get; set; }
        public bool IsReady { get; set; }
        public long Total { get; set; }
        public long Free { get; set; }
        public long Used => Total - Free;


        public string Debug => $"{GetType().Name}:" +
            $"{nameof(IsReady)}={IsReady}," +
            $"{nameof(Total)}={Total.BytesToString()}," +
            $"{nameof(Used)}={Used.BytesToString()}," +
            $"{nameof(Free)}={Free.BytesToString()}," +
            $"{nameof(Path)}={Path}";
    }
}
