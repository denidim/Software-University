using System;
using System.Collections.Generic;

namespace CustomStack//stackOfStrings
{

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }
    }


    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            var myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(new List<string> { "sd", "sd" });
            Console.WriteLine(string.Join(" ", myStack));
        }
    }
}
