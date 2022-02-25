using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace genericSwapMethodStrings
{
    class box<T>
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
        public void Swap(int index1, int index2 )
        {
            var item1 = data[index1];
            var item2 = data[index2];
            data[index2] = item1;
            data[index1] = item2;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
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
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }

}
