namespace ServerMonitor
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using ServerMonitor.Config;
    using ServerMonitor.Extensions;
    using ServerMonitor.Installers;
    using System;
    using System.Linq;

    public class Program
    {
        private const string DOTNET_ENVIRONMENT = "DOTNET_ENVIRONMENT";
        private static bool IsDevelopment => Environment.GetEnvironmentVariable(DOTNET_ENVIRONMENT) == "Development";

        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory, EnvironmentVariableTarget.Process);

            if (args.Contains("--configure", StringComparer.OrdinalIgnoreCase))
            {
                //new ConfigGenerator().Start();
                return;
            }
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
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(DOTNET_ENVIRONMENT) ?? "Production"}.json", optional: true)
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
