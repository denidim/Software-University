using System.Collections.Generic;
using System.Linq;
using System;

namespace try2
{
    public class CustomLinkedList
    {
        public int Count { get; private set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public CustomLinkedList()
        {
            //empty ctor whith defoult values
        }

        public CustomLinkedList(int value) : this()
        {
            var newNode = new Node
            {
                Value = value,
            };
            Count++;
            Head = Tail = newNode;
        }

        public CustomLinkedList(IEnumerable<int> list)
            : this(list.First())
        {
            bool isFirst = true;

            foreach (var item in list)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    var newNode = new Node()
                    {
                        Value = item,
                        Previous = Tail,
                        Next = null
                    };
                    Tail.Next = newNode;
                    Tail = newNode;
                    Count++;
                }
            }
        }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                Node newNode = new Node { Value = element };
                Head = Tail = newNode;
            }
            else
            {
                Node newNode = new Node()
                {
                    Next = Head,
                    Value = element,
                };
                Head.Previous = newNode;
                Head = newNode;
            }
            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                Node newNode = new Node { Value = element };
                Head = Tail = newNode;
            }
            else
            {
                Node newNode = new Node()
                {
                    Previous = Tail,
                    Value = element,
                };
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }

        public int RemoveFirs()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Empty list");
            }
            var curr = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                var newCurr = Head.Next;
                newCurr.Previous = null;
                Head = newCurr;
            }
            Count--;
            return curr;
        }

        public int RemoveLast()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Empty list");
            }
            var curr = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                var newCurr = Tail.Previous;
                newCurr.Next = null;
                Tail = newCurr;
            }
            Count--;
            return curr;
        }

        public void Foreach(Action<int> action)
        {
            var curr = Head;

            while (curr!=null)
            {
                action(curr.Value);
                curr = curr.Next;
            }
        }

        public int[] ToArray()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Empty list");
            }

            int[] arr = new int[Count];
            var curr = Head;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = curr.Value;
                curr = curr.Next;
            }
            return arr;
        }
    }

    public class Node
    {
        public int Value{ get; set; }

        public Node Previous { get; set; }

        public Node Next { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList myList = new CustomLinkedList(new int[] { 5, 7, 12 });
            myList.Foreach(Console.WriteLine);
            myList.RemoveFirs();
            myList.RemoveLast();
            Console.WriteLine(string.Join(" - ", myList.ToArray()));
        }
    }
}
