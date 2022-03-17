namespace Data
{
    using Engines;
    using Interpreters;

    class Program
    {
        static void Main(string[] args)
        {

            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();

            //            2for      
            //ConsoleAppender SimpleLayout CRITICAL
            //FileAppender XmlLayout
            //INFO | 3 / 26 / 2015 2:08:11 PM | Everything seems fine
            //WARNING | 3 / 26 / 2015 2:22:13 PM | Warning: ping is too high - disconnect imminent
            //ERROR | 3 / 26 / 2015 2:32:44 PM | Error parsing request
            //CRITICAL | 3 / 26 / 2015 2:38:01 PM | No connection string found in App.config
            //FATAL | 3 / 26 / 2015 2:39:19 PM | mscorlib.dll does not respond
            //        END

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;
            //var logger = new Logger(consoleAppender);
            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");


            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);
            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");


            //var simpleLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);
            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");



            ////ILayout simpleLayout = new SimpleLayout();
            ////Appender consoleAppender = new ConsoleAppender(simpleLayout);
            ////ILogger logger = new Logger(consoleAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
