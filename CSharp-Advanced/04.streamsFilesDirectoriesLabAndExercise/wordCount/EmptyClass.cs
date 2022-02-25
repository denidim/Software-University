using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> words = File.ReadAllText(wordsFilePath).ToLower().Split().ToList();

            string fileTwo = File.ReadAllText(textFilePath).ToLower();

            using StreamWriter streamWriter = new StreamWriter(outputFilePath);

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string pattern = $@"(\b{word}\b)";

                MatchCollection matches = Regex.Matches(fileTwo, pattern);

                if (matches.Count > 0)
                {
                    result.Add(word, matches.Count);
                }
            }

            foreach (var item in result.OrderByDescending(x => x.Value))
            {
                streamWriter.WriteLine($"{item.Key} - {item.Value}");
            }
        }

    }
}
