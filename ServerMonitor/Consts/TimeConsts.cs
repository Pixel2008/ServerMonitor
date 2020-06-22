namespace ServerMonitor.Consts
{
    internal static class TimeConsts
    {
        private const int ONE_SECOND = 1;
        private const int ONE_MINUTE = 60 * ONE_SECOND;
        private const int ONE_HOUR = 60 * ONE_MINUTE;
        private const int ONE_DAY = 24 * ONE_HOUR;
        private const int ONE_MONTH = 30 * ONE_DAY;

        public const int INTERVAL_MIN = ONE_MINUTE;
        public const int INTERVAL_MAX = ONE_MONTH;
        public const int INTERVAL_DEFAULT = ONE_DAY;

        public const int DELAY_MIN = ONE_SECOND;
        public const int DELAY_MAX = ONE_HOUR;
        public const int DELAY_DEFAULT = 10 * ONE_SECOND;
    }
}
