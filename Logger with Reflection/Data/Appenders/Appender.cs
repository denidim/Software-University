namespace Data.Appenders
{
    using Layouts;
    using Loggers.Enums;

    public abstract class Appender : IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int Count { get; protected set; }

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public abstract void Append(string datetime, ReportLevel reporLevel, string message);

        public virtual string AppenderInfo()
            => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.GetType().Name}, Messages appended: {this.Count}";

    }
}
