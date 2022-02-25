using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int staringNumber = int.Parse(Console.ReadLine());
            int finalNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combination = 0;
            bool isfound = false;
            for (int i = staringNumber; i <= finalNumber ; i++)
            {
                for (int j = staringNumber; j <= finalNumber ; j++)
                {
                    combination++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combination} ({i} + {j} = {magicNumber})");
                        isfound = true;
                        break;
                    }
                }
                if (isfound)
                {
                    break;
                }
            }
            if (!isfound)
            {
                Console.WriteLine($"{combination} combinations - neither equals {magicNumber}");
            }
        }
    }
}
