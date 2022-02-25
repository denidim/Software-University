using System;
using System.Collections.Generic;
using System.Linq;

namespace sumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArray();

            int[,] matrix= new int[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                int[] arr1 = ReadArray();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = arr1[j];
                }
                Console.WriteLine();
            }
            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);
            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
