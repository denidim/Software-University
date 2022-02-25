using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int foodCount = int.Parse(Console.ReadLine());
            Queue<int> orderQueue = new Queue<int>(orders);
            if (orderQueue.Count > 0)
            {
                Console.WriteLine(orderQueue.Max());
            }
            while (orderQueue.Count>0)
            {
                int curr = orderQueue.Peek();
                if (curr <= foodCount)
                {
                    foodCount -= curr;
                    orderQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orderQueue)}");
                    break;
                }
            }
            if (orderQueue.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
