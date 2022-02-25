using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath);

        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string outputFilePath)
        {
            ZipFile.ExtractToDirectory(zipArchiveFilePath, outputFilePath);
        }
    }
}
