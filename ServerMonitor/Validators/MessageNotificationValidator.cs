using ServerMonitor.Config;
using ServerMonitor.Consts;
using System;

namespace ServerMonitor.Validators
{
    internal class MessageNotificationValidator : IMessageNotificationValidator
    {
        private readonly IMessageRecipientValidator messageRecipientValidator;

        public MessageNotificationValidator(IMessageRecipientValidator messageRecipientValidator)
        {
            this.messageRecipientValidator = messageRecipientValidator;
        }
        public void Validate(MessageNotificationConfig config)
        {
            if(config == null)
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
                if (string.IsNullOrWhiteSpace(config.From))
                {
                    throw new ArgumentNullException(nameof(config.From));
                }
                if (string.IsNullOrWhiteSpace(config.Display))
                {
                    throw new ArgumentNullException(nameof(config.Display));
                }
                if (config.Limit < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.Limit), $"Minimum value is 1");
                }
                if (config.Limit > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.Limit), $"Maximum value is 100");
                }
                if (config.MessageRecipients == null || config.MessageRecipients.Count == 0)
                {
                    throw new ArgumentNullException(nameof(config.MessageRecipients));
                }
                foreach (var messageRecipient in config.MessageRecipients)
                {
                    this.messageRecipientValidator.Validate(messageRecipient);
                }
            }
        }
    }
}
