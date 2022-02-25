using System;

namespace symbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doesNotExist = true;
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string symbols = Console.ReadLine();
                for (int j = 0; j <matrix.GetLength(1); j++)
                {
                    matrix[i, j] += symbols[j];
                }
            }
            char ch = char.Parse(Console.ReadLine());
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ch)
                    {
                        Console.WriteLine($"({i}, {j})");
                        doesNotExist = false;
                        break;
                    }
                    if (doesNotExist == false)
                    {
                        break;
                    }
                }

            }
            if (doesNotExist)
            {
                Console.WriteLine($"{ch} does not occur in the matrix");
            }
        }
    }
}
