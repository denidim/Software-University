namespace Data.Loggers
{
    using System.Collections.Generic;
    using Appenders;

    public interface ILogger
    {
        public IEnumerable<IAppender> Appenders { get; }

        //Info > Warning > Error > Critical > Fatal.
        void Info(string dateTime, string message);

        void Warning(string datetime, string message);

        void Error(string datetime, string message);

        void Critical(string datetime, string message);

        void Fatal(string datetime, string message);
    }
}
