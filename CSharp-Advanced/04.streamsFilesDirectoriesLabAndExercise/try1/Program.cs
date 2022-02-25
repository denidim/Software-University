using System;
using System.IO;

namespace try1//recursive subDirectories sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"/Users/whocares/Desktop/softuni copy/c#Advance/streamsFilesDirectories/Resources/06. Folder Size/TestFolder";

            var totalLength = GetTotalLength(directoryPath);
            Console.WriteLine(totalLength);
        }

        static long GetTotalLength(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            long totalLength = 0;
            foreach (var item in files)
            {
                totalLength += new FileInfo(item).Length;
            }

            var subDirectories = Directory.GetDirectories(directoryPath);
            foreach (var item in subDirectories)
            {
                totalLength += GetTotalLength(item);
            }

            return totalLength;
        }
    }
}
