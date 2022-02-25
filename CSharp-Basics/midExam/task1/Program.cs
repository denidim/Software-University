using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Text;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterDayPerson = double.Parse(Console.ReadLine());
            double foodDayPerson = double.Parse(Console.ReadLine());
            double groupWater = waterDayPerson * players*days;
            double groupFood = foodDayPerson * players*days;
            bool finish = true;


            for (int i = 1; i <= days; i++)
            {
                groupEnergy -= double.Parse(Console.ReadLine());
                if (groupEnergy <= 0)
                {
                    finish = false;
                    break;
                }
                if (i % 2 == 0)
                {
                    groupWater *= 0.70;
                    groupEnergy += groupEnergy * 0.05;
                }
                if (i % 3 == 0)
                {
                    groupFood -= groupFood / players;
                    groupEnergy += groupEnergy * 0.10;
                }
            }

            if (finish)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {groupFood:f2} food and {groupWater:f2} water.");
            }
        }
    }
}
