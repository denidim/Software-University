using System;

namespace _07.WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            string text = Console.ReadLine().ToLower();
            if ((num >= 10 && num <= 18) && (text == "monday" || text == "tuesday" || text == "wednesday" || text == "thursday" || text == "friday" || text == "saturday"))
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
