﻿using ServerMonitor.Config;
using ServerMonitor.Consts;
using System;

namespace ServerMonitor.Validators
{
    internal class DiskDriveConfigValidator : IDiskDriveConfigValidator
    {
        private readonly IPartitionValidator partitionValidator;

        public DiskDriveConfigValidator(IPartitionValidator partitionValidator)
        {
            this.partitionValidator = partitionValidator;
        }
        public void Validate(DiskDriveConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            if (config.Enabled)
            {
                if (config.DelayStart < TimeConsts.DELAY_MIN)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.DelayStart), $"Minimum value is {TimeConsts.DELAY_MIN}");
                }
                if (config.DelayStart > TimeConsts.DELAY_MAX)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.DelayStart), $"Maximum value is {TimeConsts.DELAY_MAX}");
                }
                if (config.RunInterval < TimeConsts.INTERVAL_MIN)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.RunInterval), $"Minimum value is {TimeConsts.INTERVAL_MIN}");
                }
                if (config.RunInterval > TimeConsts.INTERVAL_MAX)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.RunInterval), $"Maximum value is {TimeConsts.INTERVAL_MAX}");
                }
                if (config.Partitions == null || config.Partitions.Count == 0)
                {
                    throw new ArgumentNullException(nameof(config.Partitions));
                }
                foreach (var partition in config.Partitions)
                {
                    this.partitionValidator.Validate(partition);
                }
            }
        }
    }
}