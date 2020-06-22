using ServerMonitor.Validators;

namespace ServerMonitor.Tests.Validators
{
    internal class MemoryConfigValidatorContext
    {
        private readonly MemoryConfigValidator obj;

        public MemoryConfigValidatorContext()
        {
            this.obj = new MemoryConfigValidator();
        }

        public MemoryConfigValidator Build()
        {
            return this.obj;
        }
    }
}
