﻿namespace ServerMonitor.Validators
{
    using ServerMonitor.Config;
    using System;
    using System.Threading.Tasks;

    internal class DiskDriveConfigValidator : IDiskDriveConfigValidator
    {
        private readonly IPartitionValidator partitionValidator;

        public DiskDriveConfigValidator(IPartitionValidator partitionValidator)
        {
            this.partitionValidator = partitionValidator;
        }
        public async Task ValidateAsync(DiskDriveConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            if (config.Enabled)
            {
                if (config.DelayStart < Consts.AppConsts.DELAY_MIN)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.DelayStart), $"Minimum value is {Consts.AppConsts.DELAY_MIN}");
                }
                if (config.DelayStart > Consts.AppConsts.DELAY_MAX)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.DelayStart), $"Maximum value is {Consts.AppConsts.DELAY_MAX}");
                }
                if (config.RunInterval < Consts.AppConsts.INTERVAL_MIN)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.RunInterval), $"Minimum value is {Consts.AppConsts.INTERVAL_MIN}");
                }
                if (config.RunInterval > Consts.AppConsts.INTERVAL_MAX)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.RunInterval), $"Maximum value is {Consts.AppConsts.INTERVAL_MAX}");
                }
                if (config.Partitions == null || config.Partitions.Count == 0)
                {
                    throw new ArgumentNullException(nameof(config.Partitions));
                }
                foreach (var partition in config.Partitions)
                {
                    await this.partitionValidator.ValidateAsync(partition);
                }
            }            
        }
    }
}
