using System.Collections;
using System.Collections.Generic;
using Data.Loggers;

namespace Data.Interpreters
{
    public interface ICommandInterpreter
    {
        bool CreateLogger(IEnumerable<string> appendersInfo);
        void AppendMessages(IEnumerable<string> reportLevelTimeAndMessageInputInfo);
        void PrintInfo();
    }
}
