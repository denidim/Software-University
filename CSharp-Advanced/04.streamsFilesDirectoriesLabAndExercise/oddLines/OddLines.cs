using System;
using System.IO;

namespace oddLines
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"input.txt";
            string outputFilePath = @"../../../output.txt";
            OddLines.ExtractOddLines(inputFilePath, outputFilePath);
        }
    }
}
