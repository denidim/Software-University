using System;

namespace _04.Sequence2kPlus1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 0;
            while (k <= n)
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            }
        }
    }
}
