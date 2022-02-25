using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double freeCubicMeters = width * length * height;
            double totalFreeSpace = 0;
            int boxesCubicMeters = 0;
            string stopper = Console.ReadLine();
            while (stopper != "Done")
            {
                int boxes = int.Parse(stopper);
                boxesCubicMeters += boxes;
                double freeSpace = freeCubicMeters - boxesCubicMeters;
                totalFreeSpace = freeSpace;

                if (freeSpace <= 0 )
                {
                    Console.WriteLine($"No more free space! You need {Math .Abs (freeCubicMeters  - boxesCubicMeters )} Cubic meters more.");
                    break;
                }
                stopper = Console.ReadLine();
            }
            if (totalFreeSpace > 0)
            {
                Console.WriteLine($"{totalFreeSpace} Cubic meters left.");
            }
        }
    }
}
