using System;

namespace _11.FruitShop
{
    class Program
    {
        static void Main(string[] args)
        //banana / apple / orange / grapefruit / kiwi / pineapple / grapes
        //Monday / Tuesday / Wednesday / Thursday / Friday / Saturday / Sunday
        {
            string fruit = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());
            if (day == "monday"|| day == "tuesday"|| day == "wednesday"|| day == "thursday"|| day == "friday")
            {
                switch (fruit)
                {
                    case "banana": Console.WriteLine("{0:f2}",quantity * 2.50); break;
                    case "apple": Console.WriteLine("{0:f2}", quantity * 1.20); break;
                    case "orange": Console.WriteLine("{0:f2}", quantity * 0.85); break;
                    case "grapefruit": Console.WriteLine("{0:f2}", quantity * 1.45); break;
                    case "kiwi": Console.WriteLine("{0:f2}", quantity * 2.70); break;
                    case "pineapple": Console.WriteLine("{0:f2}", quantity * 5.50); break;
                    case "grapes": Console.WriteLine("{0:f2}", quantity * 3.85); break;
                    default: Console.WriteLine("error"); break;
                }
            }
            else if (day == "saturday" || day == "sunday")
            {
                switch (fruit)
                {
                    case "banana": Console.WriteLine("{0:f2}", quantity * 2.70); break;
                    case "apple": Console.WriteLine("{0:f2}", quantity * 1.25); break;
                    case "orange": Console.WriteLine("{0:f2}", quantity * 0.90); break;
                    case "grapefruit": Console.WriteLine("{0:f2}", quantity * 1.60); break;
                    case "kiwi": Console.WriteLine("{0:f2}", quantity * 3.00); break;
                    case "pineapple": Console.WriteLine("{0:f2}", quantity * 5.60); break;
                    case "grapes": Console.WriteLine("{0:f2}", quantity * 4.20); break;
                    default: Console.WriteLine("error"); break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            if (score == "positive")
            {
                discount += ((20 / 100.0) * discount);
            }
            else if (score == "negative")
            {
                discount -= ((10 / 100.0) * discount);
            }
        }
    }
}
