using System;
using System.Linq;
using System.Threading;

namespace tuple
{
    class Tuple<T , V>
    {
        public T Item1 { get; set; }
        public V Item2 { get; set; }

    }

    class Program
    {
        static void Main(string[] args)

        {
            var tuple1 = new Tuple<string[], string>();
            string[] input = Console.ReadLine().Split().ToArray();
            string[] curr = new string[2];
            curr[0] = input[0];
            curr[1] = input[1];
            tuple1.Item1 = curr;
            tuple1.Item2 = input[2];
            Console.WriteLine($"{string.Join(" ",tuple1.Item1)} -> {tuple1.Item2}");

            var tuple2 = new Tuple<string, int>();
            string[] input1 = Console.ReadLine().Split().ToArray();
            tuple2.Item1 = input1[0];
            tuple2.Item2 = int.Parse(input1[1]);
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");

            var tuple3 = new Tuple<int, double>();
            string[] input3 = Console.ReadLine().Split().ToArray();
            tuple3.Item1 = int.Parse(input3[0]);
            tuple3.Item2 = double.Parse(input3[1]);
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2}");
        }
    }
}
