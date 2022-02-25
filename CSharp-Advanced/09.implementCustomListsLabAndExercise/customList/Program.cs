using System;

namespace customList
{
    class Program
    {
        static void Main(string[] args)
        {
            //void Add(int element) -Adds the given element to the end of the list
            //int RemoveAt(int index) -Removes the element at the given index
            //bool Contains(int element) -Checks if the list contains the given element returns(True or False)
            //void Swap(int firstIndex, int secondIndex) -Swaps the elements at the given indexes

            var list = new List<string>();
            list.Add("10");
            list.Add("20");
            list.Add("20");
            list.RemoveAt(1);
            Console.WriteLine(list.Count);
            list.Swap(0, 1);
            Console.WriteLine(list.Contains("10"));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }
    }
}
