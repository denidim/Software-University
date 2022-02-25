using System;
using System.Linq;

namespace squaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArray();
            int[,] matrix = FillMatrix(size);
            int counter = FindingEqualSubMatrixCount(size, matrix);
            Console.WriteLine(counter);
        }

        private static int FindingEqualSubMatrixCount(int[] size, int[,] matrix)
        {
            int counter = 0;
            for (int i = 0; i < size[0] - 1; i++)
            {
                for (int j = 0; j < size[1] - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] &&
                        matrix[i + 1, j] == matrix[i + 1, j + 1] &&
                        matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static int[,] FillMatrix(int[] size)
        {
            int[,] matrix = new int[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                char[] arr1 = ReadCharArray();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] += arr1[j];
                }
            }

            return matrix;
        }

        private static char[] ReadCharArray()
        {
            return Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(char.Parse)
            .ToArray();
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
