using System;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string pass = Console.ReadLine();
            string tryPass = Console.ReadLine();
            while (pass != tryPass)
            {
                tryPass = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {userName}!");
        }
    }
}
