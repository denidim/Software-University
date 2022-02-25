using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator//listyIterator
{

    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(params T[] input)
        {
            this.list = new List<T>(input);
            index = 0;
        }

        public bool Move()
        {
            bool canMove = HasNext();

            if (canMove)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index < list.Count - 1;
        }

        public void Print()
        {
            if (list.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[index]);
        }

    }

    class StartUp//Program
    {
        static void Main(string[] args)
        {

            string[] input= Console.ReadLine().Split();

            ListyIterator<string> myList = null;

            while (input[0] != "END")
            {
                if (input[0] == "Create")
                {
                    myList = new ListyIterator<string>(input.Skip(1).ToArray());
                }
                else if (input[0] == "Move")
                {
                    Console.WriteLine(myList.Move());
                }
                else if (input[0] == "Print")
                {
                    try
                    {
                        myList.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if(input[0] == "HasNext")
                {
                    Console.WriteLine(myList.HasNext());
                    
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
