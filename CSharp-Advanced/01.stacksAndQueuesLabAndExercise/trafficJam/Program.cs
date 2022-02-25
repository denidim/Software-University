using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Queue<string> cars = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            int counter=0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                if (input == "green")
                {
                    if (n > cars.Count)
                    {
                        n = cars.Count;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        sb.AppendLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{sb.ToString().Trim()}");
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
