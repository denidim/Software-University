using System;
namespace _02.SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            var degrees = int.Parse(Console.ReadLine());
            var time = Console.ReadLine().ToLower();
            var outfit = "";
            var shoes = "";
            if (10 <= degrees && degrees <= 18)
            {
                if (time == "morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                if (time == "afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                if (time == "evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            if (18 < degrees && degrees <= 24)
            {
                if (time == "morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                if (time == "afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                if (time == "evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            if (degrees >= 25)
            {
                if (time == "morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                if (time == "afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                if (time == "evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
