namespace Data.Interpreters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Appenders;
    using CustomFiles;
    using Layouts;
    using Loggers;
    using Loggers.Enums;

    public class CommandInterpreter:ICommandInterpreter
    {
        ILogger logger = null;

        public bool CreateLogger(IEnumerable<string> appendersInfo)
        {
            List<IAppender> appenders = new List<IAppender>();

            foreach (var appenderInfo in appendersInfo)
            {
                string[] currAppenderInfo = appenderInfo
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string typeName = currAppenderInfo[0];
                string layoutName = currAppenderInfo[1];

                ILayout layout = (ILayout)GenerateClass(layoutName,null);
                IAppender appender;

                if (typeName == "FileAppender")
                {
                    appender = (IAppender)GenerateClass(typeName, new object[] { layout, new LogFile() });
                }
                else
                {
                    appender = (IAppender)GenerateClass(typeName,new object[] { layout });
                }
                if (currAppenderInfo.Length == 3)
                {
                    bool isValidLogLevel = Enum
                        .TryParse(currAppenderInfo[2], true, out ReportLevel reportLevel);

                    if (isValidLogLevel)
                    {
                        appender.ReportLevel = reportLevel;
                    }
                    else
                    {
                        throw new InvalidCastException("Enum ReportLevel is not in the right format");
                    }
                }
                appenders.Add(appender);
            }

            logger= new Logger(appenders.ToArray());

            return true;
        }

        public void AppendMessages(IEnumerable<string> reportLevelTimeAndMessageInputInfo)
        {
            foreach (var appenderInfo in reportLevelTimeAndMessageInputInfo)
            {
                string[] currAppenderInfo = appenderInfo
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string levelType = currAppenderInfo[0];
                string time = currAppenderInfo[1];
                string message = currAppenderInfo[2];

                InvokeByReflection(levelType, time, message);
            }
        }

        public void PrintInfo()
        {
            foreach (var appender in this.logger.Appenders)
            {
                Console.WriteLine(appender.AppenderInfo());
            }
        }

        private void InvokeByReflection(string levelType, string time, string message)
        {
            var method = logger.GetType()
                                .GetMethods()
                                .Where(x => x.Name.ToLower() == levelType.ToLower())
                                .FirstOrDefault();

            method.Invoke(logger, new object[] { time, message });
        }

        //this method takes a type name and return object
        //so it need to be casted to its user class
        private object GenerateClass(string typeName, object[] constructorParams)
        {
            Type classType = Assembly
               .GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name == typeName);

            if (classType != null)
            {
                return Activator.CreateInstance(classType, constructorParams);
            }
            throw new ArgumentNullException("Class type not found");
        }
    }
}
