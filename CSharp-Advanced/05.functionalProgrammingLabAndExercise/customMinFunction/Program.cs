using System;
using System.Collections.Generic;
using System.Linq;

namespace customMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            //Console.WriteLine(nums.Min());
            Func<List<int>, int> smalestInt = n =>
            {
                int minValue = int.MaxValue;
                foreach (var item in n)
                {
                    if (item < minValue)
                    {
                        minValue = item;
                    }
                }
                return minValue;
            };

            Console.WriteLine(smalestInt(nums));

        }
    }
}
