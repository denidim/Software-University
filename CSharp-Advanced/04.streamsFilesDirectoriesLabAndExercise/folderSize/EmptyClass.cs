using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            using StreamWriter streamWriter = new StreamWriter(outputFilePath);
            double total = GetTotalLength(folderPath);
            total = total / 1204 / 1204;
            streamWriter.WriteLine($"{total} KB");
        }
        static long GetTotalLength(string folderParh)
        {
            string[] files = Directory.GetFiles(folderParh);
            long totalLength = 0;
            foreach (var item in files)
            {
                totalLength += new FileInfo(item).Length;
            }

            var subDirectories = Directory.GetDirectories(folderParh);
            foreach (var item in subDirectories)
            {
                totalLength += GetTotalLength(item);
            }

            return totalLength;
        }
    }
}
