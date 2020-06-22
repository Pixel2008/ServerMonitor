using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerMonitor.Config;
using ServerMonitor.Installers;
using ServerMonitor.Tools;
using System;
using System.Diagnostics;
using System.Linq;

namespace ServerMonitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Contains("--configure", StringComparer.OrdinalIgnoreCase))
            {
                //new ConfigGenerator().Start();
                return;
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var isWindows = OS.IsWindows();
            var isLinux = OS.IsLinux();

            if (!(isWindows || isLinux))
                throw new NotSupportedException("OS not supported!");

            var host = Host.CreateDefaultBuilder(args);

            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            if (isService)
            {
                if (isWindows)
                    host.UseWindowsService();
                else if (isLinux)
                    host.UseSystemd();
            }
            else
            {
                host.UseConsoleLifetime();
            }

            host.ConfigureServices((hostContext, services) =>
                {
                    var configSection = hostContext.Configuration.GetSection("AppConfig");
                    services.Configure<AppConfig>(configSection);
                                        
                    ConverterInstaller.Install(services);
                    ComponentInstaller.Install(services);
                    ValidatorInstaller.Install(services);
                    ServiceInstaller.Install(services);
                });
            return host;
        }
    }
}
