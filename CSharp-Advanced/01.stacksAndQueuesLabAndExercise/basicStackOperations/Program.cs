using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace basicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int popCount = input[1];
            int toLookFor = input[2];
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numStack = new Stack<int>(nums);
            for (int i = 0; i < popCount; i++)
            {
                numStack.Pop();
            }
            if (numStack.Contains(toLookFor))
            {
                Console.WriteLine("true");
            }
            else if(numStack.Count>0)
            {
                int min = int.MaxValue;
                while (numStack.Count>0)
                {
                    int curr = numStack.Pop();
                    if (curr < min)
                    {
                        min = curr;
                    }
                }
                Console.WriteLine(min);
            }
            else
            {
                Console.WriteLine("0");
            }





        }
    }
}
