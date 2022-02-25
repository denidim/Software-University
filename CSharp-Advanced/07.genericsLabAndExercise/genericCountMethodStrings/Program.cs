using System.Collections.Generic;
using System.Text;
using System;

namespace genericCountMethodStrings
{
    class box<T> where T: IComparable
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
            var box = new box<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }
            string element = Console.ReadLine();
            Console.WriteLine(box.Count(element));
        }
    }

}

