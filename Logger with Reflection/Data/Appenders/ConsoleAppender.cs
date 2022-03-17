using System;
namespace Data.Appenders
{
    using Layouts;
    using Loggers.Enums;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string datetime, ReportLevel reporLevel, string message)
        {
            this.Count++;

            string appendedMessage = string.Format(this.Layout.Format, datetime, reporLevel, message);

            Console.WriteLine(appendedMessage);
        }
    }
}
