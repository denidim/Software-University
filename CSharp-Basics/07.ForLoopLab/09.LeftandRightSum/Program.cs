using System;

namespace _09.LeftandRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sum1 = 0;
            var sum2 = 0;
            for (int i = 0; i < 2 * n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    sum1 += num;
                }
                else
                {
                    sum2 += num;
                }
            }
            if (sum1 == sum2)
            {
                Console.WriteLine("Yes, sum = " + sum1);
            }
            else
            {
                Console.WriteLine("No, diff = " + Math.Abs(sum2 - sum1));
            }
        }
    }
}
