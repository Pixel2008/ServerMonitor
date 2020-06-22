namespace ServerMonitor.Tools
{
    internal static class App
    {
        public static string AppNameVersion()
        {
            return System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
    }
}
