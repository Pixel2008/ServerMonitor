using System;

namespace ServerMonitor.Tools
{
    internal static class App
    {
        public const string DOTNET_ENVIRONMENT = "DOTNET_ENVIRONMENT";
        public static bool IsDevelopment => Environment.GetEnvironmentVariable(DOTNET_ENVIRONMENT) == "Development";

        public static string AppNameVersion()
        {
            return System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
    }
}
