using System;
using System.Collections.Generic;
using System.Linq;

namespace setsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> firstSet = new HashSet<string>();
            HashSet<string> secondSet = new HashSet<string>();
            List<string> result = new List<string>();
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < inputArr[1]; i++)
            {
                firstSet.Add(Console.ReadLine());
            }
            for (int i = 0; i < inputArr[0]; i++)
            {
                secondSet.Add(Console.ReadLine());
            }
            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}


