using System;
using System.Collections.Generic;
using System.Linq;

namespace sumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArray();
            int[] sum = new int[size[1]];
            int[,] matrix = new int[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                int[] arr1 = ReadRow();
                for (int j = 0; j < size[1]; j++)
                {
                    sum[j] += arr1[j];
                    matrix[i, j] = arr1[j];
                }
            }
            foreach (var item in sum)
            {
                Console.WriteLine(item);
            }
        }
        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        private static int[] ReadRow()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
