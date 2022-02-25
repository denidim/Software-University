using System;
using System.Linq;

namespace pascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];

            for (int i = 0; i < height; i++)
            {
                int length = i + 1;
                long[] row = new long[length];
                row[0] = 1;
                row[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    row[j] = triangle[i - 1][j] + triangle[i - 1][j - 1];
                }
                triangle[i] = row;
            }
            for (int i = 0; i < triangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}
