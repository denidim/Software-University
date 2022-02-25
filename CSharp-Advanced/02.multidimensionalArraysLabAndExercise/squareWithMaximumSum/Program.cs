using System;
using System.Collections.Generic;
using System.Linq;

namespace squareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadInput();
            int[,] matrix = new int[size[0], size[1]];
            FillingMatrix(matrix);
            int sum = 0;
            int maxSum = int.MinValue;
            int[] subMatrixRow1 = new int[2];
            int[] subMatrixRow2 = new int[2];
            for (int i = 0; i < size[0] - 1; i++)
            {
                for (int j = 0; j < size[1] - 1; j++)
                {
                    sum += matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        SetingOutput(matrix, subMatrixRow1, subMatrixRow2, i, j);
                    }
                    sum = 0;
                }
            }
            Print(maxSum, subMatrixRow1, subMatrixRow2);
        }
        private static void Print(int maxSum, int[] subMatrixRow1, int[] subMatrixRow2)
        {
            Console.WriteLine(string.Join(" ", subMatrixRow1));
            Console.WriteLine(string.Join(" ", subMatrixRow2));
            Console.WriteLine(maxSum);
        }
        private static void SetingOutput(int[,] matrix, int[] subMatrixRow1, int[] subMatrixRow2, int i, int j)
        {
            subMatrixRow1[0] = matrix[i, j];
            subMatrixRow1[1] = matrix[i, j + 1];
            subMatrixRow2[0] = matrix[i + 1, j];
            subMatrixRow2[1] = matrix[i + 1, j + 1];
        }
        private static void FillingMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] readRow = ReadInput();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] += readRow[j];
                }
            }
        }
        private static int[] ReadInput()
        {
            return Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}

