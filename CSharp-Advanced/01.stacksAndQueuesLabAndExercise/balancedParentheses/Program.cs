using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace balancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> brackets = new Stack<char>();
            string input = Console.ReadLine();
            bool isValid = true;
            foreach (char item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    brackets.Push(item);
                    continue;
                }
                if (brackets.Count == 0)
                {
                    isValid = false;
                    break;
                }
                if (brackets.Count == 0)
                    break;
                if (brackets.Peek() == '(' && item == ')')
                    brackets.Pop();
                else if (brackets.Peek() == '[' && item == ']')
                    brackets.Pop();
                else if (brackets.Peek() == '{' && item == '}')
                    brackets.Pop();
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
            Console.WriteLine();
        }
    }
}
