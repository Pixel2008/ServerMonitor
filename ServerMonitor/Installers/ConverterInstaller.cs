using Microsoft.Extensions.DependencyInjection;
using ServerMonitor.Converters;

namespace ServerMonitor.Installers
{
    internal static class ConverterInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.AddTransient<IMimeMessageConverter, MimeMessageConverter>();
            services.AddTransient<IMessageConverter, MessageConverter>();
        }
    }
}
