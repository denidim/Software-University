using System;

namespace _05.BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var rent = double.Parse(Console.ReadLine());
            var cake = (20/100.0)*rent;
            var drinks = cake - ((45 / 100.0) * cake);
            var clown = 1 * (rent / 3);
            var budget = rent + cake + drinks + clown;
            Console.WriteLine(budget);
        }
    }
}
