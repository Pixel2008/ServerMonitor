namespace ServerMonitor.Tests.Contexts
{
    using ServerMonitor.Validators;

    internal class MemoryConfigValidatorContext : BaseContext<MemoryConfigValidator>
    {
        public MemoryConfigValidatorContext()
        {
            this.Obj = new MemoryConfigValidator();
        }
    }
}
