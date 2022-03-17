
namespace Data.Appenders
{
    using Data.Loggers.Enums;
    using Layouts;

    public interface IAppender
    {
        public ReportLevel ReportLevel{ get; set; }

        public ILayout Layout { get; }

        public int Count { get; }

        void Append(string datetime, ReportLevel reporLevel ,string message);

        string AppenderInfo();

    }
}
