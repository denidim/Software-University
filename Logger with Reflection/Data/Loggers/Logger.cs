namespace Data.Loggers
{
    using System.Collections.Generic;
    using Appenders;
    using Loggers.Enums;
    public class Logger : ILogger
    {
        public IEnumerable<IAppender> Appenders { get; }

        public Logger(params IAppender[] appenders )
        {
            this.Appenders = new List<IAppender>(appenders);
        }

        public void Critical(string dateTime, string message)
        {
            AppendAll(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            AppendAll(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            AppendAll(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            AppendAll(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            AppendAll(dateTime, ReportLevel.Warning, message);
        }

        private void AppendAll(string dateTime, ReportLevel logLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                if (logLevel >= appender.ReportLevel)
                {
                    appender.Append(dateTime, logLevel, message);

                }
            }
        }
    }
}
