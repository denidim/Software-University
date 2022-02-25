using System;

namespace _07.MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string stopper = Console.ReadLine();
            int min = int.MaxValue;
            while (stopper != "Stop")
            {
                int num = int.Parse(stopper);
                if (min > num)
                {
                    min = num;
                }
                stopper = Console.ReadLine();
            }
            Console.WriteLine(min);
        }
    }
}
