using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader streamReader = new StreamReader(inputFilePath);

            using StreamWriter streamWriter = new StreamWriter(outputFilePath);

            int lineCounter = 0;

            while (!streamReader.EndOfStream)
            {
                int punctCounter = 0;
                int charCounter = 0;

                string line = streamReader.ReadLine();

                foreach (var item in line)
                {
                    if (char.IsPunctuation(item))
                    {
                        punctCounter++;
                    }
                    else if (char.IsLetter(item))
                    {
                        charCounter++;
                    }
                }

                lineCounter++;

                streamWriter.WriteLine($"Line {lineCounter}: {line} ({charCounter})({punctCounter})");
            }
        }
    }
}
