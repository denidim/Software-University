using System;
using System.IO;
using System.Threading.Tasks;

namespace try2//OddLines
{
    public class OddLines
    {
        static void Main()
        {

            string inputFile = @"input.txt";
            string outputFile = @"../../../output.txt";
            ExtractOddLines(inputFile, outputFile);

        }
        public static async void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader str = new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            int lineNumbers = 0;
                string line = await str.ReadLineAsync();
                    while (line != null)
                    {
                        if (lineNumbers % 2 != 0)
                        {
                            await sw.WriteLineAsync(line);
                        }

                        lineNumbers++;

                        line = await str.ReadLineAsync();
                    }


        }
    }

}





