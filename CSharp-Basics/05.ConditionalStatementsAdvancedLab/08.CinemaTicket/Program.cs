using System;

namespace _08.CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            int price = 0;
            switch (text)
            {
                case "monday":
                case "tuesday":price = 12;break;
                case "wednesday":
                case "thursday": price = 14; break;
                case "friday": price = 12; break;
                case "saturday":
                case "sunday": price = 16; break;
            }
            Console.WriteLine(price);
        }
    }
}
