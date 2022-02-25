using System;
using System.Collections.Generic;
using System.Linq;

namespace primaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int[] arr1 = ReadRow();
                sum += arr1[i];
            }
            Console.WriteLine(sum);
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
