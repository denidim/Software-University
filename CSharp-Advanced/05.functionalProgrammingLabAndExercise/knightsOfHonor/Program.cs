using System;
using System.Collections.Generic;
using System.Linq;

namespace knightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> action = x => x.ForEach(x=>Console.WriteLine($"Sir {x}"));
            

            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            action(names);
        }
    }
}
