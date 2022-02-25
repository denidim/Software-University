using System;
using System.Collections.Generic;
using System.Linq;

namespace stackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> calk = new Stack<int>(input);

            while (true)
            {
                string[] command = Console.ReadLine().ToLower().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "end")
                {
                    break;
                }
                if (command[0] == "add")
                {
                    calk.Push(int.Parse(command[1]));
                    calk.Push(int.Parse(command[2]));
                }
                if (command[0] == "remove")
                {
                    int a = int.Parse(command[1]);
                    if (a > calk.Count)
                    {
                        continue;
                    }
                    for (int i = 0; i < a; i++)
                    {
                        calk.Pop();
                    }
                }
            }
            while (calk.Count>1)
            {
                int a = calk.Pop();
                int b = calk.Pop();
                calk.Push(a+b);
            }
            Console.WriteLine($"Sum: {calk.Pop()}");
        }
    }
}
