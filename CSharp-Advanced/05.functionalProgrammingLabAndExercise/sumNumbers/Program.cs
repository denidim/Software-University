using System;
using System.Linq;

namespace sumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = Parser;

            int[] nums = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());
        }
        public static int Parser(string n)
        {
            return int.Parse(n);
        }
    }
}
