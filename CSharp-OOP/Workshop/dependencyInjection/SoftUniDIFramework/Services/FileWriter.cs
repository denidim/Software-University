namespace SoftUniDIFramework.Services
{
    using System.IO;
    using Contracts;

    public class FileWriter : IFileWriter
    {
        public void Write(string text)
        {
            File.WriteAllText("log.txt", text);
        }
    }
}
