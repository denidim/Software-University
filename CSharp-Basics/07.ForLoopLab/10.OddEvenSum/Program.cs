using System;

namespace _10.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int even = 0;
            int odd = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    even += num;
                }
                else
                {
                    odd += num;
                }
            }
            if (even == odd)
            {
                Console.WriteLine("Yes\r\nSum = " + even);
            }
            else
            {
                Console.WriteLine("No\r\nDiff = " + Math.Abs(even - odd));
            }
        }
    }
}
