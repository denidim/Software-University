using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator//stack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public Stack(params T[] input)
        {
            elements = new List<T>(input);
        }

        //public int Count{ get; private set; }

        public void Push(IEnumerable<T> inputListOfElements)
        {
            foreach (var item in inputListOfElements)
            {
                elements.Add(item);
            }
        }

        public T Pop()
        {
            
            if (elements.Count == 0)
            {
                Console.WriteLine("No elements");
                return default;

            }
            T result = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);

            return result;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class StartUp//Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            string input;

            while ((input=Console.ReadLine())!="END")
            {
                char[] separators = new char[] { ' ', ',' };

                string[] tockens = input.Split(separators,StringSplitOptions.RemoveEmptyEntries);

                if (tockens[0] == "Push")
                {
                    string[] elements = tockens.Skip(1).ToArray();
                    stack.Push(elements);
                }
                if(tockens[0] == "Pop")
                {
                    stack.Pop();
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
