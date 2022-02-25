using System.IO;

namespace copyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "copyMe.png";
            string outputFilePath = "../../../output.png";
            CopyBinaryFile.CopyFile(inputFilePath, outputFilePath);
        }
    }
    public class CopyBinaryFile
    {
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            byte[] buffer = new byte[4096];

            using FileStream fileStreamRead = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);

            using FileStream fileStreamWrite = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);

            while (fileStreamWrite.Length < fileStreamRead.Length)
            {
                int bytes = fileStreamRead.Read(buffer, 0, buffer.Length);

                fileStreamWrite.Write(buffer, 0, bytes);
            }
        }
    }
}
