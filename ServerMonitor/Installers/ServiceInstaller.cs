using Microsoft.Extensions.DependencyInjection;
using ServerMonitor.Core;
using ServerMonitor.Services;

namespace ServerMonitor.Installers
{
    internal static class ServiceInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.AddSingleton<IMessageQueueService, MessageQueueService>();

            services.AddTransient<IDiskDriveService, DiskDriveService>();
            services.AddHostedService<HostedService<IDiskDriveService>>();

            services.AddTransient<IMemoryService, MemoryService>();
            services.AddHostedService<HostedService<IMemoryService>>();

            services.AddTransient<IMessageSenderService, MessageSenderService>();
            services.AddHostedService<HostedService<IMessageSenderService>>();
        }
    }
}
