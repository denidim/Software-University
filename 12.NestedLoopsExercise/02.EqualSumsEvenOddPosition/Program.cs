using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= secondNum; i++)
            {
                int hundredThousands = i / 100000;
                int tenThousands = i / 10000 % 10;
                int thousands = i / 1000 % 10;
                int hundreds = i / 100 % 10;
                int thens = i / 10 % 10;
                int units = i % 10;
                int sumEven = tenThousands + hundreds + units;
                int sumOdd = hundredThousands + thousands + thens;
                if (sumEven == sumOdd )
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
