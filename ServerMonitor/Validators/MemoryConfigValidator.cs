using ServerMonitor.Config;
using ServerMonitor.Consts;
using System;

namespace ServerMonitor.Validators
{
    internal class MemoryConfigValidator : IMemoryConfigValidator
    {
        public void Validate(MemoryConfig config)
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
                if (config.MaxPercentageUsage < AppConsts.PERCENT_MIN)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.MaxPercentageUsage), $"Minimum value is {AppConsts.PERCENT_MIN}");
                }
                if (config.MaxPercentageUsage > AppConsts.PERCENT_MAX)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.MaxPercentageUsage), $"Maximum value is {AppConsts.PERCENT_MAX}");
                }
            }
        }
    }
}
