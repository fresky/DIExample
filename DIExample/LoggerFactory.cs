namespace DIExample
{
    static internal class LoggerFactory
    {
        public const string MessageboxLoggerName = "MessageBox Logger";
        public const string ConsoleLoggerName = "Console Logger";

        private static readonly ILogger m_ConsoleLogger = new ConsoleLogger();
        private static readonly ILogger m_MessageBoxLogger = new MessageBoxLogger();

        public static ILogger CreateLogger(string type="")
        {
            if (MessageboxLoggerName.Equals(type))
            {
                return m_MessageBoxLogger;
            }
            return m_ConsoleLogger;
        }
    }
}