using System;
using System.Collections.Generic;

namespace BoxOfT//boxOfT
{
    public class Box<T>
    {
        public int Count => elements.Count;

        private readonly List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }


        public void Add(T element)
        {
            elements.Add(element);
        }

        public T  Remove()
        {
            var item = elements[elements.Count-1];

            elements.Remove(item);

            return item;
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
            int count = box.Count;
        }
    }
}
