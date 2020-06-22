using System.Runtime.InteropServices;

namespace ServerMonitor.Tools
{
    internal static class OS
    {
        public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static bool IsLinux() =>RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}
