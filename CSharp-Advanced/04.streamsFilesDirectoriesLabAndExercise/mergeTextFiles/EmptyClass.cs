using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {

            using StreamReader strReader1 = new StreamReader(firstInputFilePath);
            using StreamReader strReader2 = new StreamReader(secondInputFilePath);
            using StreamWriter streamWriter = new StreamWriter(outputFilePath);

            while (!strReader1.EndOfStream && !strReader2.EndOfStream)
            {
                string line1 = strReader1.ReadLine();
                streamWriter.WriteLine(line1);
                string line2 = strReader2.ReadLine();
                streamWriter.WriteLine(line2);
            }
        }
    }
}
