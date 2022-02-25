using System;
using System.Collections.Generic;

namespace try1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var kyr = new CustomList<int>();
                kyr.RemoveFirst();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var listString = new CustomList<string>();
            listString.AddFirst("Pesho");
            listString.AddFirst("gosho");
            Console.WriteLine(string.Join(", ",listString.ToArray()));
            

            CustomList<int> list = new CustomList<int>();

            list.AddFirst(3);

            list.AddFirst(2);

            list.AddFirst(1);

            list.AddLast(4);

            list.AddLast(5);

            list.RemoveFirst();

            list.RemoveLast();
            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(", ",list.ToArray()));
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
