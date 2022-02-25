using System;

namespace sumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstGuyTime = int.Parse(Console.ReadLine());
            int secondGuyTime = int.Parse(Console.ReadLine());
            int thirdGuyTime = int.Parse(Console.ReadLine());
            var sumInSeconds = firstGuyTime + secondGuyTime + thirdGuyTime;
            var min = 0;
            if (sumInSeconds > 59)
            {
                min = min + 1;
                sumInSeconds = sumInSeconds - 60;
            }
            if (sumInSeconds > 59)
            {
                min = min + 1;
                sumInSeconds = sumInSeconds - 60;
            }
            if (sumInSeconds < 10)
            {
                Console.WriteLine(min + ":" + "0" + sumInSeconds);
            }
            else
            {
                Console.WriteLine(min + ":" + sumInSeconds);
            }
        }
    }
}

