using ServerMonitor.Extensions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Domain
{
    internal class MemoryMetrics
    {
        public double Total { get; set; }
        public double Free { get; set; }
        public double Used => Total - Free;

        public string Debug => $"{GetType().Name}:" +
            $"{nameof(Total)}={Total.BytesToString()}," +
            $"{nameof(Used)}={Used.BytesToString()}," +
            $"{nameof(Free)}={Free.BytesToString()}";
    }
}
