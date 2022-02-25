namespace wordCount
{
    class Program
    {
        static  void Main(string[] args)
        {
            string wordsFilePath = "words.txt";
            string textFilePath = "text.txt";
            string outputFilePath = @"../../../output.txt";
            WordCount.WordCount.CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }
    }
}


