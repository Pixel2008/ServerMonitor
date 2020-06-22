namespace ServerMonitor.Extensions
{
    internal static class StringExtensions
    {
        public static string NL(this string s)
        {
            return $"{s}\r\n";
        }
    }
}
