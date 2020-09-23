namespace ServerMonitor.Consts
{
    internal static class AppConsts
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

        public const int SMTP_PORT_MIN = 1;
        public const int SMTP_PORT_MAX = 65536;
        public const int SMTP_TIMEOUT_MIN = 1;
        public const int SMTP_TIMEOUT_MAX = 120;

        public const int PERCENT_MIN = 0;
        public const int PERCENT_MAX = 100;

        public const int MESSAGES_LIMIT_MIN = 1;
        public const int MESSAGES_LIMIT_MAX = 100;

    }
}
