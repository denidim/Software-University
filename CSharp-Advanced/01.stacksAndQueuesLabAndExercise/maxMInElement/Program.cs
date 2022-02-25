using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maxMInElement
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Stack<int> numsStack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (command[0] == 1)
                {
                    numsStack.Push(command[1]);
                }
                if (command[0] == 2)
                {
                    if (numsStack.Count > 0)
                    {
                        numsStack.Pop();
                    }
                }
                if (command[0] == 3)
                {
                    if (numsStack.Count > 0)
                    {
                        sb.AppendLine(numsStack.Max().ToString());
                    }
                }
                if (command[0] == 4)
                {
                    if (numsStack.Count > 0)
                    {
                        sb.AppendLine(numsStack.Min().ToString());
                    }
                }
            }
            Console.WriteLine(sb.ToString().Trim());
            Console.WriteLine(string.Join(", ",numsStack));
        }
    }
}
