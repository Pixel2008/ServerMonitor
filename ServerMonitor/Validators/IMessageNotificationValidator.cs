namespace ServerMonitor.Validators
{
    using ServerMonitor.Config;
    using System.Threading.Tasks;

    internal interface IMessageNotificationValidator
    {
        Task ValidateAsync(MessageNotificationConfig config);
    }
}