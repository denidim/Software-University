using System.IO;

public class OddLines
{
    public static async void ExtractOddLines(string inputFilePath, string outputFilePath)
    {
        using StreamReader str = new StreamReader(inputFilePath);
        using StreamWriter sw = new StreamWriter(outputFilePath);

        int curr = 0;


        while (!str.EndOfStream)
        {
            string line = await str.ReadLineAsync();

            if (curr % 2 != 0)
            {
                await sw.WriteLineAsync(line);
            }

            curr++;
        }
    }
}
