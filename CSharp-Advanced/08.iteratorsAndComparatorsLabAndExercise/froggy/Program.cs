using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace froggy
{
    class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(params int [] rocks)
        {
            stones = rocks;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i];
                }
            }

            for (int i = stones.Length-1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var lake = new Lake(arr);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
