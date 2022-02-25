using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double herMoney = double.Parse(Console.ReadLine());
            int counterSpend = 0;
            int days = 0;
            while (counterSpend < 5 && herMoney >= moneyNeeded)
            {
                days++;
                string spendOrSave = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                switch (spendOrSave)
                {
                    case "spend":counterSpend++; herMoney -= sum;
                    if (herMoney < 0)
                    {
                        herMoney = 0;
                    }
                        break;
                    case "save":counterSpend = 0; herMoney += sum;
                        break;
                }
            }
            if (herMoney >= moneyNeeded)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            else
            {
                Console.WriteLine($"You can't save the money.\r\n{days}");
            }
        }
    }
}