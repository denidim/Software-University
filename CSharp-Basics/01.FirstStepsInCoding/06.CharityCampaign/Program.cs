using System;

namespace _06.CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            var strawberryPrice = double.Parse(Console.ReadLine());
            var bananaKg = double.Parse(Console.ReadLine());
            var orangeKg = double.Parse(Console.ReadLine());
            var raspberrieKgs = double.Parse(Console.ReadLine());
            var strawberryKg = double.Parse(Console.ReadLine());

            var raspberriesPrice = strawberryPrice / 2;
            var orangePrice = raspberriesPrice - (40/100.0)*raspberriesPrice;
            var bananaPrice = raspberriesPrice - (80/100.0)*raspberriesPrice;

            var strawberryTotal = strawberryPrice * strawberryKg;
            var bananaTotal = bananaPrice * bananaKg;
            var orangeTotal = orangePrice * orangeKg;
            var raspberrieTotal = raspberriesPrice * raspberrieKgs;

            var result = strawberryTotal + bananaTotal + orangeTotal +raspberrieTotal;
            Console.WriteLine($"{result:f2}");
        }
    }
}
