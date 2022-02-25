using System;

namespace _04.VacationBookList
{
    class Program
    {
        static void Main(string[] args)
        {
            var pages = int.Parse(Console.ReadLine());
            var pH = double.Parse(Console.ReadLine());
            var days = int.Parse(Console.ReadLine());
            var result = (pages / pH) / days;
            Console.WriteLine(result);
        }
    }
}
