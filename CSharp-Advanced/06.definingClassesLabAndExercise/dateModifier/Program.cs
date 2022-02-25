using System;
using dateModifier;

namespace DefiningClasses//dateModifier
{
    public class StartUP//Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.CalculateDateDifferenceBtwDates(firstDate, secondDate);
            Console.WriteLine(days);
        }
    }
}
