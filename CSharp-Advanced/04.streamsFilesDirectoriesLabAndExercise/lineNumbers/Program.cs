using System;
using System.IO;
using System.Threading.Tasks;

namespace lineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "Input.txt";
            string outputFilePath = @"../../../output.txt";
            LineNumbers.LineNumbers.RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }
    }
}
