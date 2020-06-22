using Microsoft.Extensions.DependencyInjection;
using ServerMonitor.Components;

namespace ServerMonitor.Installers
{
    internal static class ComponentInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.AddTransient<IMessageDecorator, MessageDecorator>();
            services.AddTransient<IMessageSender, MessageSender>();
            services.AddTransient<IMemoryInfo, MemoryInfo>();
            services.AddTransient<IDiskDriveInfo, DiskDriveInfo>();
        }
    }
}
