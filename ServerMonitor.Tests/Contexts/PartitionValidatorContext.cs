namespace ServerMonitor.Tests.Contexts
{
    using ServerMonitor.Validators;

    internal class PartitionValidatorContext : BaseContext<PartitionValidator>
    {
        public PartitionValidatorContext()
        {
            this.Obj = new PartitionValidator();
        }
    }
}
