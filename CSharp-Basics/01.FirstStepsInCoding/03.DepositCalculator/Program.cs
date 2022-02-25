using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var deposit = double.Parse(Console.ReadLine());
            var term = int.Parse(Console.ReadLine());
            var intrestRate = double.Parse(Console.ReadLine());
            var intrest = deposit * intrestRate/100;
            var monthlyIntrest = intrest / 12;
            var sum = term * monthlyIntrest + deposit;
            Console.WriteLine("{0:f2}",sum);
        }
    }
}
