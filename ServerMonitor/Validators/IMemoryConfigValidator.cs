using ServerMonitor.Config;

namespace ServerMonitor.Validators
{
    internal interface IMemoryConfigValidator
    {
        void Validate(MemoryConfig memoryConfig);
    }
}