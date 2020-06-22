using ServerMonitor.Config;

namespace ServerMonitor.Validators
{
    internal interface IMessageNotificationValidator
    {
        void Validate(MessageNotificationConfig config);
    }
}