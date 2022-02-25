using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double money = 10;
            double moneyTotal = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    moneyTotal += money;
                    money += 10;
                }
            }
            Console.WriteLine(moneyTotal);
        }
    }
}
