namespace ServerMonitor.Tests.Contexts
{
    using ServerMonitor.Tests.Mocks;
    using ServerMonitor.Validators;

    internal class DiskDriveConfigValidatorContext : BaseContext<DiskDriveConfigValidator>
    {
        public DiskDriveConfigValidatorContext()
        {
            var partitionValidatorMock = new IPartitionValidatorMock();
            partitionValidatorMock.Mock_Validate();
            
            this.Obj = new DiskDriveConfigValidator(partitionValidatorMock.Object);
        }       
    }
}
