using System;
using System.IO;

namespace lineNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "text.txt";
            string outputFilePath = "../../../output.txt";
            LineNumbers.LineNumbers.ProcessLines(inputFilePath, outputFilePath);
        }
    }
}
