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
                if (config.MaxPercentageUsage < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.MaxPercentageUsage), "Minimum value is 0");
                }
                if (config.MaxPercentageUsage > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.MaxPercentageUsage), "Maximum value is 100");
                }
            }
        }
    }
}
