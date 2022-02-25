using System;
using System.Collections.Generic;
using System.Linq;

namespace listOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] rangeNumbers = Enumerable.Range(1, end).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var item in dividers)
            {
                predicates.Add(x => x % item == 0);
            }

            foreach (var item in rangeNumbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(item))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.Write(item + " ");
                }
            }

        }
    }
}
