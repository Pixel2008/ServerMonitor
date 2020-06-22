using ServerMonitor.Domain;

namespace ServerMonitor.Components
{
    internal interface IMemoryInfo
    {
        MemoryMetrics GetMemoryMetrics();
    }
}
