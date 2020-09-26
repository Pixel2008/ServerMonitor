namespace ServerMonitor.Converters
{
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IMessageConverter
    {
        Task<Message> GetAsync(DiskDriveMetrics diskDriveMetrics);
        Task<Message> GetAsync(MemoryMetrics memoryMetrics);
    }
}
