using System;
using System.IO;

namespace folderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"/Users/whocares/Desktop/softuni copy/c#Advance/streamsFilesDirectories/Resources - Lab/07. Folder Size/TestFolder";
            string outputFilePath = "../../../output.txt";

            FolderSize.FolderSize.GetFolderSize(folderPath, outputFilePath);
        }
    }
}
