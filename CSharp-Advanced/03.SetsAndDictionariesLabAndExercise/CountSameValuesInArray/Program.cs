using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double,double> intDic = new Dictionary<double,double>();

            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!intDic.ContainsKey(arr[i]))
                {
                    intDic.Add(arr[i], 1);
                }
                else
                {
                    intDic[arr[i]]++;
                }
            }
            foreach (var item in intDic)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
