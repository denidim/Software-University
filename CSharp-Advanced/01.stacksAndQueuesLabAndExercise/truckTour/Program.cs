using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] pair = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(pair);
            }
            int index = 0;
            while(true)
            {
                int totalFuel = 0;
                foreach (var item in pumps)
                {
                    int petrol = item[0];
                    int distance = item[1];
                    totalFuel += petrol - distance;
                    if (totalFuel < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        index++;
                        break;
                    }
                }
                if (totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
