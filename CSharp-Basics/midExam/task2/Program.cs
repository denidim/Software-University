using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                if (command[0] == "Include")
                {
                    coffees.Add(command[1]);
                }
                if (command[0] == "Remove")
                {
                    if (command[1] == "first")
                    {
                        if (coffees.Count < int.Parse(command[2]))
                        {
                            continue;
                        }
                        else
                        {
                            coffees.RemoveRange(0, int.Parse(command[2]));
                        }
                    }
                    else if (command[1] == "last")
                    {
                        if (coffees.Count < int.Parse(command[2]))
                        {
                            continue;
                        }
                        else
                        {
                            int from = (coffees.Count) - int.Parse(command[2]);
                            coffees.RemoveRange(from, int.Parse(command[2]));
                        }

                    }
                }
                if (command[0] == "Prefer")
                {
                    int index1 = int.Parse(command[1]);
                    string name1 = coffees[index1];
                    int index2 = int.Parse(command[2]);
                    string name2 = coffees[index2];
                    if (coffees.Count >= index1 && coffees.Count >= index2
                        && index1 != -1 && index2 != -1)
                    {
                        coffees[index1] = name2;
                        coffees[index2] = name1;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (command[0] == "Reverse")
                {
                    coffees.Reverse();
                }
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));


        }

    }
}

