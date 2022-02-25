using System;
using System.Collections.Generic;
using System.Linq;

namespace appliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    nums=nums.Select(n => n + 1).ToList();
                }
                if (command == "multiply")
                {
                    nums=nums.Select(n => n * 2).ToList();
                }
                if (command == "subtract")
                {
                    nums=nums.Select(n => n - 1).ToList();
                }
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ",nums));
                }
            }

        }
    }
}
