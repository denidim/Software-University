using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string stopper = Console.ReadLine();
            double balance = 0;
            while (stopper != "NoMoreMoney")
            {
                double payment = double.Parse(stopper);
                if (payment <= 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Increase: {payment:f2}");
                }
                balance += payment;
                stopper = Console.ReadLine();
            }
            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
