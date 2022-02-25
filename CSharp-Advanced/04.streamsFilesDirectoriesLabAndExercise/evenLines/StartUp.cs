using System;

namespace evenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"text.txt";
             
            Console.WriteLine(EvenLines.EvenLines.ProcessLines(inputFilePath));
        }
    }
}
