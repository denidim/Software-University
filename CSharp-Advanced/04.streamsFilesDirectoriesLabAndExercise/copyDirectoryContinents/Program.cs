using System;

namespace copyDirectoryContinents
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyDirectory.CopyDirectory.CopyAllFiles(inputPath, outputPath);
            // /Users/whocares/Desktop/softuni copy/from
            // /Users/whocares/Desktop/softuni copy/to
        }
    }
}
