namespace SoftUniDIFramework.Core
{
    using Contracts;
    using SoftUniDI;
    using SoftUniDI.Attributes;

    public class Engine
    {
        [Inject]
        [Named("ConsoleWriter")]
        private  IWriter consoleWriter;
        [Inject]
        private  IReader consoleReader;
        [Inject]
        [Named("FileWriter")]
        private IFileWriter fileWriter;

        //public Engine(
        //    IWriter _consoleWriter,
        //    IFileWriter _fileWriter,
        //    IReader _consoleReadr)
        //{
        //    consoleWriter = _consoleWriter;
        //    fileWriter = _fileWriter;
        //    consoleReader = _consoleReadr;
        //}
        public void Run()
        {
            string text = consoleReader.Read();
            fileWriter.Write(text);
            consoleWriter.Write(text);
        }
    }
}
