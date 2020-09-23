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
                if (string.IsNullOrWhiteSpace(config.From))
                {
                    throw new ArgumentNullException(nameof(config.From));
                }
                if (string.IsNullOrWhiteSpace(config.Display))
                {
                    throw new ArgumentNullException(nameof(config.Display));
                }
                if (config.Limit < AppConsts.MESSAGES_LIMIT_MIN)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.Limit), $"Minimum value is {AppConsts.MESSAGES_LIMIT_MIN}");
                }
                if (config.Limit > AppConsts.MESSAGES_LIMIT_MAX)
                {
                    throw new ArgumentOutOfRangeException(nameof(config.Limit), $"Maximum value is {AppConsts.MESSAGES_LIMIT_MAX}");
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
