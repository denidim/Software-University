using System;
using System.Collections.Generic;
using System.Linq;

namespace reverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDevisible = x => x % n == 0;

            nums=nums.Where(x => !isDevisible(x)).ToList();

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
