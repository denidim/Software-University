using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = int.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            var price = 0.0;
            if(season == "Spring")
            {
                price = 3000;
                if (quantity <= 6)
                {
                    price -= price * 0.1;
                }
                else if (quantity >= 7 || quantity <= 11)
                {
                    price -= price * 0.15;
                }
                else if (quantity >= 12)
                {
                    price -= price * 0.25;
                }
                if (quantity % 2 == 0)
                {
                    price -= price * 0.05;
                }
            }
            if(season == "Summer")
            {
                price = 4200;
                if (quantity <= 6)
                {
                    price -= price * 0.1;
                }
                else if (quantity >= 7 || quantity <= 11)
                {
                    price -= price * 0.15;
                }
                else if (quantity >= 12)
                {
                    price -= price * 0.25;
                }
                if (quantity % 2 == 0)
                {
                    price -= price * 0.05;
                }
            }
            if(season == "Autumn")
            {
                price = 4200;
                if (quantity <= 6)
                {
                    price -= price * 0.1;
                }
                else if (quantity >= 7 || quantity <= 11)
                {
                    price -= price * 0.15;
                }
                else if (quantity >= 12)
                {
                    price -= price * 0.25;
                }
            }
            if(season == "Winter")
            {
                price = 2600;
                if (quantity <= 6)
                {
                    price -= price * 0.1;
                }
                else if (quantity >= 7 && quantity <= 11)
                {
                    price -= price * 0.15;
                }
                
                else if (quantity >= 12)
                {
                    price -= price * 0.25;
                }
                if (quantity % 2 == 0)
                {
                    price -= price * 0.05;
                }
            }
            
            if(budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
            }
        }
    }
}
