using System;
using System.IO.Compression;

namespace zipAndExtracts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFilePath = "input";
            string zipArchiveFilePath = @"/Users/whocares/Desktop/softuni copy/c#Advance/streamsFilesDirectories/folder/zip.zip";//@"../../../zipHere/zip.zip"
            string outputFilePath = @"/Users/whocares/Desktop/softuni copy/c#Advance/streamsFilesDirectories/folder";//@"../../../unZipHere"

            ZipAndExtract.ZipAndExtract.ZipFileToArchive(inputFilePath,zipArchiveFilePath);

            ZipAndExtract.ZipAndExtract.ExtractFileFromArchive(zipArchiveFilePath, outputFilePath);
        }
    }
}


