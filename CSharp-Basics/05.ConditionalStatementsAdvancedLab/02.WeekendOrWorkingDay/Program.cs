using System;

namespace _02.WeekendOrWorkingDay
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = Console.ReadLine().ToLower();
            switch (day)
            {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday": Console.WriteLine("Working day"); break;
                case "saturday":
                case "sunday": Console.WriteLine("Weekend"); break;
                default: Console.WriteLine("Error"); break;
            }
        }
    }
}
