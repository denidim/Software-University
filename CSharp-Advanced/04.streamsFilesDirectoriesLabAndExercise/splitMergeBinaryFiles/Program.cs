using System;
using System.IO;

namespace SplitMergeBinaryFiles
{
    public class SplitMergeBinaryFile
    {
        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream fileStreamReadr = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);

            long allBytes = fileStreamReadr.Length;

            long firstBytes = (long)Math.Ceiling(allBytes / 2.0);

            long secondBytes = allBytes - firstBytes;

            byte[] buffer1 = new byte[firstBytes];
            byte[] buffer2 = new byte[secondBytes];
            int bytes1 = fileStreamReadr.Read(buffer1, 0, buffer1.Length);
            int bytes2 = fileStreamReadr.Read(buffer2, 0, buffer2.Length);

            fileStreamReadr.Close();

            using FileStream fileStreamWriter1 = new FileStream(partOneFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            fileStreamWriter1.Write(buffer1, 0, bytes1);

            fileStreamWriter1.Close();

            using FileStream fileStreamWriter2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            fileStreamWriter2.Write(buffer2, 0, bytes2);

            fileStreamWriter2.Close();

        }
        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream fileStreamReadr1 = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read);
            byte[] newBuffer1 = new byte[fileStreamReadr1.Length];
            int bytes3 = fileStreamReadr1.Read(newBuffer1, 0, newBuffer1.Length);
            fileStreamReadr1.Close();

            using FileStream fileStreamReadr2 = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read);
            byte[] newBuffer2 = new byte[fileStreamReadr2.Length];
            int bytes4 = fileStreamReadr2.Read(newBuffer2, 0, newBuffer2.Length);
            fileStreamReadr2.Close();


            using FileStream fileStreamWriterJoinedPng = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write);
            fileStreamWriterJoinedPng.Write(newBuffer1, 0, bytes3);
            fileStreamWriterJoinedPng.Write(newBuffer2, 0, bytes4);
            fileStreamWriterJoinedPng.Close();

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = "example.png";
            string partOneFilePath = "../../../part-1.bin";
            string partTwoFilePath = "../../../part-2.bin";
            string joinedFilePath = "../../../joined.png";

            SplitMergeBinaryFile.SplitBinaryFile(sourceFilePath, partOneFilePath, partTwoFilePath);
            SplitMergeBinaryFile.MergeBinaryFiles(sourceFilePath, partOneFilePath, joinedFilePath);
        }
    }
}
