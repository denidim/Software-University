using System.IO;
namespace Data.Appenders
{
    using System;
    using Data.CustomFiles;
    using Layouts;
    using Loggers.Enums;

    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/log.txt";

        public LogFile LogFile{ get;}

        public FileAppender(ILayout layout,LogFile logFile) : base(layout)
        {
            this.LogFile = logFile;
        }

        public override void Append(string datetime, ReportLevel reporLevel, string message)
        {
            this.Count++;

            string appendMessage = string.Format(this.Layout.Format, datetime, reporLevel, message);

            LogFile.Write(appendMessage);

            File.AppendAllText(FilePath, appendMessage + Environment.NewLine);
        }

        public override string AppenderInfo()
        {
            return $"{base.AppenderInfo()}, File size: {this.LogFile.Size}";
        }
    }
}
