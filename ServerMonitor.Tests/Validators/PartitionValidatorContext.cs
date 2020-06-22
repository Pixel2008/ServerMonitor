using ServerMonitor.Validators;

namespace ServerMonitor.Tests.Validators
{
    internal class PartitionValidatorContext
    {
        private readonly PartitionValidator obj;

        public PartitionValidatorContext()
        {
            this.obj = new PartitionValidator();
        }

        public PartitionValidator Build()
        {
            return this.obj;
        }
    }
}
