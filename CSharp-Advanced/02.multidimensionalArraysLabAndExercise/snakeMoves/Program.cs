using System;
using System.Linq;

namespace snakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadLine();
            string[,] matrix = new string[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        matrix[i, j] += GetNextChar();
                    }
                }
                else
                {
                    for (int j = size[1] - 1; j >= 0; j--)
                    {
                        matrix[i, j] += GetNextChar();
                    }
                }
            }
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int counter = 0;
        static string inputWord=Console.ReadLine();
        private static char GetNextChar()
        {
            char nextChar = inputWord[counter];
            counter++;
            if (counter >= inputWord.Length)
            {
                counter = 0;
            }
            return nextChar;
        }
        static int[] ReadLine()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

