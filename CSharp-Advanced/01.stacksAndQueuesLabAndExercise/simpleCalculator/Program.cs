using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace simpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Stack<string> st = new Stack<string>(input);
            Stack<string> calk = new Stack<string>(input.Reverse());

            while (calk.Count>1)
            {
                int a = int.Parse(calk.Pop());
                string op = calk.Pop();
                int b = int.Parse(calk.Pop());
                if (op == "+")
                {
                    calk.Push((a+b).ToString());
                }
                else
                {
                    calk.Push((a - b).ToString());
                }
            }
            Console.WriteLine(calk.Pop());
        }
    }
}
