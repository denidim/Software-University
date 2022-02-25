using System;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            var discount = 0.0;
            var price = 0.0;
            var days = int.Parse(Console.ReadLine());
            var nights = days - 1;
            var roomType = Console.ReadLine();
            var score = Console.ReadLine();

            if(roomType == "room for one person")
            {
                price = 18.00;
            }
            if (roomType == "apartment")
            {
                price = 25.00;
                if (nights < 10)
                {
                    discount = 0.3 * nights*price;
                }
                else if (nights == 10 || nights <= 15)
                {
                    discount = 0.35 * nights * price;
                }
                else if (nights > 15)
                {
                    discount = 0.5 * nights * price;
                }
            }
            if (roomType == "president apartment")
            {
                price = 35.00;
                if (nights < 10)
                {
                    discount  = 0.1 * nights * price;
                }
                else if (nights == 10 || nights <= 15)
                {
                    discount = 0.15 * nights * price;
                }
                else if (nights > 15)
                {
                    discount = 0.2 * nights * price;
                }
            }
            var totalPrice = nights * price - discount;
            if (score == "positive")
            {
                totalPrice += 0.25 * totalPrice;
            }
            else if (score == "negative")
            {
                totalPrice -= 0.1 * totalPrice;
            }
            Console.WriteLine("{0:f2}",totalPrice);
        }
    }
}
