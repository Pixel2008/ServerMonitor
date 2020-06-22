using ServerMonitor.Config;
using System;

namespace ServerMonitor.Validators
{
    internal class PartitionValidator : IPartitionValidator
    {
        public void Validate(DiskDriveConfig.Partition partition)
        {
            if (partition == null)
            {
                throw new ArgumentNullException(nameof(partition));
            }
            if (string.IsNullOrWhiteSpace(partition.Path))
            {
                throw new ArgumentNullException(nameof(partition.Path));
            }
            if (partition.MinPercentageUsage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(partition.MinPercentageUsage), "Minimum value is 0");
            }
            if (partition.MinPercentageUsage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(partition.MinPercentageUsage), "Maximum value is 100");
            }
        }
    }
}
