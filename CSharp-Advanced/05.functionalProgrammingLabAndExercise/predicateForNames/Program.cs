using System;
using System.Linq;

namespace predicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int l = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(' ');

            foreach (var name in names.Where(n => n.Length <= l))
            {
                Console.WriteLine(name);
            }
        }
    }
}
