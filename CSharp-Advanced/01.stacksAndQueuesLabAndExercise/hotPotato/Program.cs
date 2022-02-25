using System;
using System.Collections.Generic;

namespace hotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childern = Console.ReadLine().Split();

            int n = int.Parse(Console.ReadLine());

            Queue<string> game = new Queue<string>(childern);

            while (game.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    string curr = game.Dequeue();
                    game.Enqueue(curr);
                }
                Console.WriteLine($"Removed {game.Dequeue()}");
            }
            Console.WriteLine($"Last is {game.Dequeue()}");
        }
    }
}
