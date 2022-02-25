using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            var budget = int.Parse(Console.ReadLine());
            var rosesPrice = 5.00;
            var dahilasPrice = 3.80;
            var tulipsPrice = 2.80;
            var narcissusPrice = 3.00;
            var gladiolusPrice = 2.50;
            var price = 0.0;
            
            if (type == "Roses")
            {
                price = rosesPrice * quantity;
                if (quantity > 80)
                {
                    price = (quantity * rosesPrice)-(quantity * rosesPrice * 0.1);
                }
            }
            else if (type == "Dahlias")
            {
                price = dahilasPrice * quantity;
                if(quantity > 90)
                {
                    price = (quantity * dahilasPrice) - (quantity * dahilasPrice * 0.15);
                }
            }
            else if (type == "Tulips")
            {
                price = tulipsPrice * quantity;
                if (quantity > 80)
                {
                    price = (quantity * tulipsPrice) - (quantity * tulipsPrice * 0.15);
                }
            }
            else if (type == "Narcissus")
            {
                price = narcissusPrice * quantity;
                if(quantity < 120)
                {
                    price = (quantity * narcissusPrice) + (quantity * narcissusPrice * 0.15);
                }
            }
            else if (type == "Gladiolus")
            {
                price = gladiolusPrice * quantity;
                if(quantity < 80)
                {
                    price = (quantity * gladiolusPrice) + (quantity * gladiolusPrice * 0.2);
                }
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {type} and {budget - price:f2} leva left.");
            }
            else if (budget < price)
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(budget - price):f2} leva more.");
            }

        }
    }
}
