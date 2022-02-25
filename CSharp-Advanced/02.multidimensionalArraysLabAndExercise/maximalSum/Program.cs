using System;
using System.Linq;

namespace maximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadLine();
            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                FillMatrix(size, matrix, i);
            }
            int max = int.MinValue;
            int sum = 0;
            int[] startIndex = new int[2];
            int[] lastIndex = new int[2];
            for (int i = 0; i < size[0]-2; i++)
            {
                for (int j = 0; j < size[1]-2; j++)
                {
                    sum = SumIndexes(matrix, sum, i, j);
                    if (sum > max)
                    {
                        max = sum;
                        TakePositionsForPrinting(startIndex, lastIndex, i, j);
                    }
                    sum = 0;
                }
            }
            Console.WriteLine($"Sum = {max}");
            for (int i = startIndex[0]; i <= lastIndex[0]; i++)
            {
                for (int j = startIndex[1]; j <= lastIndex[1]; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void TakePositionsForPrinting(int[] startIndex, int[] lastIndex, int i, int j)
        {
            startIndex[0] = i;
            startIndex[1] = j;
            lastIndex[0] = i + 2;
            lastIndex[1] = j + 2;
        }

        private static int SumIndexes(int[,] matrix, int sum, int i, int j)
        {
            sum += matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
            return sum;
        }

        private static void FillMatrix(int[] size, int[,] matrix, int i)
        {
            int[] row = ReadLine();
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] += row[j];
            }
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
