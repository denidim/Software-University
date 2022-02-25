using System;
using System.Linq;

namespace threeuple
{
    class Threeuple<T, V, E>
    {
        public T Item1 { get; set; }
        public V Item2 { get; set; }
        public E Item3 { get; set; }

    }

    class Program
    {
        static void Main(string[] args)

        {
            var threeuple1 = new Threeuple<string, string, string>();
            string[] input1 = Console.ReadLine().Split().ToArray();
            string name = $"{input1[0]} {input1[1]}";
            string adres = input1[2];
            string town = string.Join(" ",input1.Skip(3));

            threeuple1.Item1 = name;
            threeuple1.Item2 = adres;
            threeuple1.Item3 = town;

            Console.WriteLine($"{threeuple1.Item1} -> {threeuple1.Item2} -> {threeuple1.Item3}");

            var threeuple2 = new Threeuple<string, int, bool>();
            string[] input2 = Console.ReadLine().Split().ToArray();
            string name1 = input2[0];
            int beer = int.Parse(input2[1]);
            bool drunk = input2[2] == "drunk";

            threeuple2.Item1 = name1;
            threeuple2.Item2 = beer;
            threeuple2.Item3 = drunk;

            Console.WriteLine($"{threeuple2.Item1} -> {threeuple2.Item2} -> {threeuple2.Item3}");

            var threeuple3 = new Threeuple<string, double, string>();
            string[] input3 = Console.ReadLine().Split().ToArray();
            string name2 = input3[0];
            double money = double.Parse(input3[1]);
            string bank = input3[2];

            threeuple3.Item1 = name2;
            threeuple3.Item2 = money;
            threeuple3.Item3 = bank;

            Console.WriteLine($"{threeuple3.Item1} -> {threeuple3.Item2} -> {threeuple3.Item3}");
        }
    }
}

