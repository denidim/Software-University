using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace songsQueue
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(songs);
            while (queue.Count>0)
            {
                string input = Console.ReadLine();
                if (input == "Play")
                {
                    queue.Dequeue();
                }
                else if (input =="Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                else
                {
                    int index = input.IndexOf(' ');
                    string song = input.Substring(index + 1);
                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
