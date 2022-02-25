using System;
using System.Collections.Generic;
using System.Linq;

namespace wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clotesInWardeobe =
                new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clotes = input[1].Split(',');

                if (!clotesInWardeobe.ContainsKey(color))
                {
                    clotesInWardeobe.Add(color, new Dictionary<string, int>());
                   
                }
                foreach (var item in clotes)
                {
                    if (!clotesInWardeobe[color].ContainsKey(item))
                    {
                        clotesInWardeobe[color].Add(item, 1);
                    }
                    else
                    {
                        clotesInWardeobe[color][item]++;
                    }
                }
            }
            string[] toFind = Console.ReadLine().Split();
            string colorToFind = toFind[0];
            string clotesToFind = toFind[1];
            bool colorExists = false;
            foreach (var color in clotesInWardeobe)
            {
                if (color.Key.ToString() == colorToFind)
                {
                    colorExists = true;
                }
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clotes  in color.Value)
                {
                    if (clotes.Key == clotesToFind && colorExists == true)
                    {
                        Console.WriteLine($"* {clotes.Key} - {clotes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clotes.Key} - {clotes.Value}");
                    }
                }

            }

        }
    }
}
