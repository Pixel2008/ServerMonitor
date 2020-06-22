using ServerMonitor.Config;
using ServerMonitor.Consts;
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
            if (partition.MinPercentageUsage < AppConsts.PERCENT_MIN)
            {
                throw new ArgumentOutOfRangeException(nameof(partition.MinPercentageUsage), $"Minimum value is {AppConsts.PERCENT_MIN}");
            }
            if (partition.MinPercentageUsage > AppConsts.PERCENT_MAX)
            {
                throw new ArgumentOutOfRangeException(nameof(partition.MinPercentageUsage), $"Maximum value is {AppConsts.PERCENT_MAX}");
            }
        }
    }
}
