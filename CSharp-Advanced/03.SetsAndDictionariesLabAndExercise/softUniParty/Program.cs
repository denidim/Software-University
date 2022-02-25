using System;
using System.Collections.Generic;

namespace softUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }
                if (Char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                else if (regular.Contains(input))
                {
                    regular.Remove(input);
                }
            }

            int sum = regular.Count + vip.Count;
            Console.WriteLine(sum);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}

