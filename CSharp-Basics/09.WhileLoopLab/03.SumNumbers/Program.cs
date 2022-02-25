using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            while (num > sum)
            {
                sum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}
