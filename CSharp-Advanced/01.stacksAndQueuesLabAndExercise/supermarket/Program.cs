using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Queue<string> name = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (input == "Paid")
                {
                    while (name.Count>0)
                    {
                        sb.AppendLine(name.Dequeue());
                    }
                }
                else
                {
                    name.Enqueue(input);
                }
            }
            Console.WriteLine(sb.ToString().Trim());
            Console.WriteLine($"{name.Count} people remaining.");
        }
    }
}
