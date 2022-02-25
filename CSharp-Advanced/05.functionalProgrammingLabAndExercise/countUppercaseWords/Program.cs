using System;
using System.Linq;

namespace countUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> func = str => str[0] == str.ToUpper()[0];

            Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(func)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
