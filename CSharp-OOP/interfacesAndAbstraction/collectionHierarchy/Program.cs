using System;
using collectionHierarchy.Models;

namespace collectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{addCollection.Add(input[i])} ");
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{addRemoveCollection.Add(input[i])} ");
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{myList.Add(input[i])} ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
        }
    }
}
