using System;
using System.Collections.Generic;

namespace parkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(", ",StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }
                string direction = input[0];

                string number = input[1];

                

                if (direction == "IN")
                {
                    set.Add(number);
                }
                else
                {
                    set.Remove(number);
                }
            }
            if (set.Count > 0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
