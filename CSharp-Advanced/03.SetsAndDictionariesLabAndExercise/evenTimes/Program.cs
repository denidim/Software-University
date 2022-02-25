using System;
using System.Collections.Generic;
using System.Linq;

namespace evenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> intDic = new Dictionary<string,int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string curr = Console.ReadLine();
                if (!intDic.ContainsKey(curr))
                {
                    intDic.Add(curr, 1);
                }
                else
                {
                    intDic[curr]++;
                }
            }
            foreach (var item in intDic.Where(x=>x.Value%2==0))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
