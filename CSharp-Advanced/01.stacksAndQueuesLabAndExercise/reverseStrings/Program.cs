using System;
using System.Collections.Generic;
using System.Linq;

namespace reverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> chStack= new Stack<string>();
            string input = Console.ReadLine();
            string str = "";
            for (int i = 0; i < input.Length; i++)
            {
                chStack.Push(input[i].ToString());
            }
            while (chStack.Count>0)
            {
                str += chStack.Pop();
            }
            Console.WriteLine(str);

        }
    }
}
