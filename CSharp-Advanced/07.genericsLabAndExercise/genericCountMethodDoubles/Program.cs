using System;
using System.Collections.Generic;

namespace genericCountMethodDoubles
{
    class box<T> where T : IComparable
    {
        public List<T> data;

        public box()
        {
            data = new List<T>();
        }

        public void Add(T element)
        {
            data.Add(element);
        }

        public int Count(T element)
        {
            int count = 0;
            foreach (var item in data)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var box = new box<double>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }
            double element = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(element));
        }
    }

}

