using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string stopper = Console.ReadLine();
            int max = int.MinValue;
            while(stopper != "Stop")
            {
                int num = int.Parse(stopper);
                if (max < num)
                {
                    max = num;
                }
                stopper = Console.ReadLine();
            }
            Console.WriteLine(max);
        }
    }
}
