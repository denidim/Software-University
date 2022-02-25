using System;
using System.Collections;
using System.Collections.Generic;

namespace customStack
{
    public class Stack<T>:IEnumerable<T>
    {
        //void Push(int element) – Adds the given element to the stack
        //int Pop() – Removes the last added element
        //int Peek() – Returns the last element in the stack without removing it
        //void ForEach(Action<int> action) – Goes through each of the elements in the stack

        private const int InitialCapacity = 4;
        private T[] elements;

        public Stack()
        {
            elements = new T[InitialCapacity];
        }

        public int Count{ get; private set; }

        public void Push(T element)
        {
            if (Count == elements.Length)
            {
                Resize();
            }

            elements[Count++] = element;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in elements)
            {
                action(item);
            }
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[Count-1];
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            T result = elements[Count-1];

            Count--;

            if (Count <= elements.Length / 4)
            {
                Shrink();
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private void Shrink()
        {
            T[] copyArray = new T[elements.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copyArray[i] = elements[i];
            }
            elements = copyArray;
        }

        private void Resize()
        {
            T[] copyArray = new T[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                copyArray[i] = elements[i];
            }
            elements = copyArray;

            //Array.Copy(elements, copyArray, elements.Length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            foreach (var item in stack)
            {
                Console.WriteLine(item);
             }
        }
    }
}
