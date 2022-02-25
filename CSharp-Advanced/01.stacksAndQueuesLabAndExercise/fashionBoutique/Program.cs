using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] box = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int begginingRackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clotes = new Stack<int>(box);
            int rackCapacity = begginingRackCapacity;
            int counter = 1;
            while (clotes.Count>0)
            {
                int curr = clotes.Peek();
                if (rackCapacity - curr >= 0)
                {
                    clotes.Pop();
                    rackCapacity -= curr;
                }
                else
                {
                    counter++;
                    rackCapacity = begginingRackCapacity;
                }
            }
            Console.WriteLine(counter);

        }
    }
}
