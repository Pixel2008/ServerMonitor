using Microsoft.Extensions.DependencyInjection;
using ServerMonitor.Validators;

namespace ServerMonitor.Installers
{
    internal class ValidatorInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.AddTransient<IMessageValidator, MessageValidator>();
            services.AddTransient<IMessageNotificationValidator, MessageNotificationValidator>();
            services.AddTransient<ISMTPValidator, SMTPValidator>();
            services.AddTransient<IMessageRecipientValidator, MessageRecipientValidator>();
            services.AddTransient<IDiskDriveConfigValidator, DiskDriveConfigValidator>();
            services.AddTransient<IMemoryConfigValidator, MemoryConfigValidator>();
            services.AddTransient<IPartitionValidator, PartitionValidator>();
        }
    }
}
