namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Config;
    using System.Collections.Generic;

    internal class MessageNotificationConfigBuilder : BaseBuilder<MessageNotificationConfig>
    {
        public MessageNotificationConfigBuilder WithDelayStart(int delayStart)
        {
            this.Obj.DelayStart = delayStart;
            return this;
        }
        public MessageNotificationConfigBuilder WithDisplay(string display)
        {
            this.Obj.Display = display;
            return this;
        }

        public MessageNotificationConfigBuilder WithEnabled(bool enabled)
        {
            this.Obj.Enabled = enabled;
            return this;
        }

        public MessageNotificationConfigBuilder WithFrom(string from)
        {
            this.Obj.From = from;
            return this;
        }

        public MessageNotificationConfigBuilder WithLimit(int limit)
        {
            this.Obj.Limit = limit;
            return this;
        }

        public MessageNotificationConfigBuilder WithMessageRecipients(IList<MessageRecipient> recipients)
        {
            this.Obj.MessageRecipients = recipients;
            return this;
        }
        
        public MessageNotificationConfigBuilder WithRunInterval(int runInterval)
        {
            this.Obj.RunInterval = runInterval;
            return this;
        }       
    }
}
