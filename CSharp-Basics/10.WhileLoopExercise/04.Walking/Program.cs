using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int stepSum = 0;
            string steps = Console.ReadLine();
            while (steps != "Going home")
            {
                int newSteps = int.Parse(steps);
                stepSum += newSteps;
                if (stepSum >= goal)
                {
                    break;
                }
                steps = Console.ReadLine();
            }
            if (goal > stepSum)
            {
                stepSum += int.Parse(Console.ReadLine());
            }
            if (goal > stepSum)
            {
                Console.WriteLine($"{Math.Abs(goal - stepSum)} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine($"Goal reached! Good job!\r\n{stepSum - goal} steps over the goal!");
            }
        }
    }
}
