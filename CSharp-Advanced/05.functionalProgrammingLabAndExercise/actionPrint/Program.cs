using System;

namespace actionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> action = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            string[] input = Console.ReadLine().Split(' ');

            action(input);

        }
    }
}
