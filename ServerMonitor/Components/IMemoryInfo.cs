namespace ServerMonitor.Components
{
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IMemoryInfo
    {
        Task<MemoryMetrics> GetMemoryMetricsAsync();
    }
}
