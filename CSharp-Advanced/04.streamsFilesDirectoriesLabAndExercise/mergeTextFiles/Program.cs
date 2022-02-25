using System;
using System.IO;

namespace mergeTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInputFilePath = @"input1.txt";
            string secondInputFilePath = @"input2.txt";
            string outputFilePath = "../../../output.txt";
            MergeFiles.MergeFiles.MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }
    }
}
