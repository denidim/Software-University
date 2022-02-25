using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers

    {
        public static async void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader sr = new StreamReader(inputFilePath);

            using StreamWriter sw = new StreamWriter(outputFilePath);

            int counter = 0;


            while (!sr.EndOfStream)
            {
                counter++;
                string line = await sr.ReadLineAsync();

                await sw.WriteLineAsync($"{counter}. {line}");

            }

        }
    }
}
