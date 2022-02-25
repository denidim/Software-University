using System;
using System.Collections.Generic;
using System.Linq;

namespace findEvensOrOdds
{
    class Program
    {

        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x % 2 == 0;
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int from = input[0];
            int to = input[1];
            List<int> nums = new List<int>();
            for (int i = from; i <= to; i++)
            {
                nums.Add(i);
            }
            string condition = Console.ReadLine();
            if (condition == "even")
            {
                Console.WriteLine(string.Join(" ",nums.Where(x=>isEven(x))));
            }
            else
            {
                Console.WriteLine(string.Join(" ", nums.Where(x => !isEven(x))));
            }
        }
    }
}

