using System;
using System.Collections.Generic;
using System.Linq;

namespace countSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> intDic = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];
                if (!intDic.ContainsKey(curr))
                {
                    intDic.Add(curr, 1);
                }
                else
                {
                    intDic[curr]++;
                }
            }
            foreach (var item in intDic)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
