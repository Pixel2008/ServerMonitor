namespace ServerMonitor.Validators
{
    using ServerMonitor.Config;
    using System.Threading.Tasks;

    internal interface IMemoryConfigValidator
    {
        Task ValidateAsync(MemoryConfig memoryConfig);
    }
}