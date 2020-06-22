using ServerMonitor.Config;
using System.Collections.Generic;

namespace ServerMonitor.Tests.Builders
{
    internal class MessageNotificationConfigBuilder
    {
        private readonly MessageNotificationConfig config;

        public MessageNotificationConfigBuilder()
        {
            this.config = new MessageNotificationConfig();
        }
        public MessageNotificationConfigBuilder WithDelayStart(int delayStart)
        {
            this.config.DelayStart = delayStart;
            return this;
        }
        public MessageNotificationConfigBuilder WithDisplay(string display)
        {
            this.config.Display = display;
            return this;
        }

        public MessageNotificationConfigBuilder WithEnabled(bool enabled)
        {
            this.config.Enabled = enabled;
            return this;
        }

        public MessageNotificationConfigBuilder WithFrom(string from)
        {
            this.config.From = from;
            return this;
        }

        public MessageNotificationConfigBuilder WithLimit(int limit)
        {
            this.config.Limit = limit;
            return this;
        }

        public MessageNotificationConfigBuilder WithMessageRecipients(IList<MessageRecipient> recipients)
        {
            this.config.MessageRecipients = recipients;
            return this;
        }
        
        public MessageNotificationConfigBuilder WithRunInterval(int runInterval)
        {
            this.config.RunInterval = runInterval;
            return this;
        }

        public MessageNotificationConfig Build()
        {
            return this.config;
        }
    }
}
