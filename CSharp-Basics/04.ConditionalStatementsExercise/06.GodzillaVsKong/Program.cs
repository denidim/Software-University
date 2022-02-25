using System;

namespace _06.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var statist = double.Parse(Console.ReadLine());
            var costumePrice = double.Parse(Console.ReadLine())*statist;
            var decor = 0.1 * budget;
            if(statist>150)
            {
                costumePrice -= 0.1 * costumePrice;
            }
            if(costumePrice + decor > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {costumePrice + decor - budget:f2} leva more.");

            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (costumePrice + decor):f2} leva left.");
            }

        }
    }
}
