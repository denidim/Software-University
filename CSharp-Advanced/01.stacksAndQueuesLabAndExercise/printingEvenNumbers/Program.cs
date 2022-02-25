using System;
using System.Collections.Generic;
using System.Linq;

namespace printingEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(input);
            Queue<int> result = new Queue<int>();
            while (queue.Count>0)
            {
                int curr = queue.Peek();
                if (curr % 2 == 0)
                {
                    result.Enqueue(curr);
                    queue.Dequeue();
                }
                else
                {
                    queue.Dequeue();
                }
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
