using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = string.Empty;
            var money = 0.0;
            string place = string.Empty;
            if (budget <= 100)
            {
                destination = "Somewhere in Bulgaria";
                switch (season)
                {
                    case "summer": money = (30 / 100.0) * budget; place = "Camp"; break;
                    case "winter": money = (70 / 100.0) * budget; place = "Hotel"; break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Somewhere in Balkans";
                switch (season)
                {
                    case "summer": money = (40 / 100.0) * budget; place = "Camp"; break;
                    case "winter": money = (80 / 100.0) * budget; place = "Hotel"; break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Somewhere in Europe";
                place = "Hotel";
                money = (90 / 100.0) * budget;

            }
            Console.WriteLine($"{destination}");
            Console.WriteLine($"{place} - {money:F2}");
        }
    }
}
