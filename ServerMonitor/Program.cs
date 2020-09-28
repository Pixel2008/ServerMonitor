namespace ServerMonitor
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using ServerMonitor.Config;
    using ServerMonitor.Extensions;
    using ServerMonitor.Installers;
    using ServerMonitor.Tools;
    using System;

    public class Program
    {        
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory, EnvironmentVariableTarget.Process);
          
            var configuration = GetConfiguration();
            Log.Logger = GetLogger(configuration);
            
            Log.Logger.Information("Starting");
            
            GetHost(args).Build().Run();
            
            Log.Logger.Information("Stopping");
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(App.DOTNET_ENVIRONMENT) ?? "Production"}.json", optional: true)
               .AddEnvironmentVariables()
               .Build();
        }
        private static ILogger GetLogger(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        private static IHostBuilder GetHost(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .WithOS(args)
                .UseSerilog()
                .ConfigureServices(Services);
                
            return host;
        }
        private static void Services(HostBuilderContext context, IServiceCollection services)
        {
            var configSection = context.Configuration.GetSection("AppConfig");
            services.Configure<AppConfig>(configSection);

            ConverterInstaller.Install(services);
            ComponentInstaller.Install(services);
            ValidatorInstaller.Install(services);
            ServiceInstaller.Install(services);

            services.AddLogging();
        }
    }
}
