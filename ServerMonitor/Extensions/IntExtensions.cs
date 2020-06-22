namespace ServerMonitor.Extensions
{
    internal static class IntExtensions
    {
        public static int InRange(this int value, int minValue, int maxValue, int defaultValue)
        {
            if (value >= minValue && value <= maxValue)
                return value;
            return defaultValue;
        }
    }
}
