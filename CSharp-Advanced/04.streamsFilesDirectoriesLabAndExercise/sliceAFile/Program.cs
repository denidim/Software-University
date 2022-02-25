using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace sliceAFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int parts = 4;
            byte[] buffer = new byte[4096];
            int totalBytes = 0;

            using FileStream inputFileStream = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read);

            int partSize = (int)Math.Ceiling((decimal)inputFileStream.Length / parts);
            for (int i = 1; i <= parts; i++)
            {
                int readBytes = 0;

                using FileStream outputFileStream = new FileStream($"Part-{i}.txt", FileMode.Create, FileAccess.Write);
                while (readBytes < partSize && totalBytes<inputFileStream.Length)
                {
                    int bytesLenghtToRead = Math.Min(buffer.Length, partSize - readBytes);

                    int bytes = await inputFileStream.ReadAsync(buffer, 0, bytesLenghtToRead);

                    await outputFileStream.WriteAsync(buffer, 0, bytes);

                    readBytes += bytes;
                    totalBytes += bytes;
                }
            }
        }
    }
}


using System;
using System.IO;

namespace splitMergeBinaryFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileStreamReadr = new FileStream("example.png", FileMode.Open, FileAccess.Read);

            long allBytes = fileStreamReadr.Length;

            long firstBytes = (long)Math.Ceiling(allBytes / 2.0);

            long secondBytes = allBytes - firstBytes;

            byte[] buffer1 = new byte[firstBytes];
            byte[] buffer2 = new byte[secondBytes];
            fileStreamReadr.Read(buffer1, 0, buffer1.Length);
            fileStreamReadr.Read(buffer2, 0, buffer2.Length);

            using FileStream fileStreamWriter1 = new FileStream($"../../../part-1.bin", FileMode.Create, FileAccess.Write);

            fileStreamWriter1.Write(buffer1, 0, buffer1.Length);

            using FileStream fileStreamWriter2 = new FileStream($"../../../part-2.bin", FileMode.Create, FileAccess.Write);

            fileStreamWriter2.Write(buffer2, 0, buffer2.Length);


            using FileStream fileStreamWriterJoinedPng = new FileStream($"../../../joined.png", FileMode.Create, FileAccess.Write);

            using FileStream fileStreamReadr1 = new FileStream($"../../../part-1.bin", FileMode.Open, FileAccess.Read);
            byte[] newBuffer1 = new byte[fileStreamReadr1.Length];
            int bytes = fileStreamReadr1.Read(newBuffer1, 0, newBuffer1.Length);

            fileStreamWriterJoinedPng.Write(newBuffer1, 0, bytes);

            using FileStream fileStreamReadr2 = new FileStream($"../../../part-2.bin", FileMode.Open, FileAccess.Read);
            byte[] newBuffer2 = new byte[fileStreamReadr2.Length];
            int bytes1 = fileStreamReadr2.Read(newBuffer2, 0, newBuffer2.Length);

            fileStreamWriterJoinedPng.Write(newBuffer2, 0, bytes1);

        }
    }
}
