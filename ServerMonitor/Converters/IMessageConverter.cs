using ServerMonitor.Domain;

namespace ServerMonitor.Converters
{
    internal interface IMessageConverter
    {
        Message Get(DiskDriveMetrics diskDriveMetrics);
        Message Get(MemoryMetrics memoryMetrics);
    }
}
