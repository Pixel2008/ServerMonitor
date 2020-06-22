using System;

namespace ServerMonitor.Extensions
{
    internal static class DoubleExtensions
    {
        public static double InRange(this double value, double minValue, double maxValue, double defaultValue)
        {
            if (value >= minValue && value <= maxValue)
                return value;
            return defaultValue;
        }

        public static string BytesToString(this double byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            double bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}
