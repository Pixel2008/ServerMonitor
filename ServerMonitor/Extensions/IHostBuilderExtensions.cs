namespace ServerMonitor.Extensions
{
    using Microsoft.Extensions.Hosting;
    using ServerMonitor.Tools;
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal static class IHostBuilderExtensions
    {
        public static IHostBuilder WithOS(this IHostBuilder host, string[] args)
        {
            var isWindows = OS.IsWindows;
            var isLinux = OS.IsLinux;
            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            if (isWindows && isService)
            {
                return host.UseWindowsService();
            }

            if (isLinux && isService)
            {
                return host.UseSystemd();
            }

            if (isWindows || isLinux)
            {
                return host.UseConsoleLifetime();
            }

            throw new NotSupportedException("OS not supported!");
        }
    }
}
