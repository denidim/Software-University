using System;
using System.Linq;

namespace diagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            int count = n;
            for (int i = 0; i < n; i++)
            {
                int[] arr1 = ReadRow();
                sum1 += arr1[i];
                sum2 += arr1[count - 1];
                count--;
            }
            Console.WriteLine($"{Math.Abs(sum2 - sum1)}");
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

