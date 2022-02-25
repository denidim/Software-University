﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace periodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
            }
            Console.WriteLine(string.Join(" ",set));
        }
    }
}
