using System;

namespace _01.ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string input = Console.ReadLine();
                if(input == "Stop")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
