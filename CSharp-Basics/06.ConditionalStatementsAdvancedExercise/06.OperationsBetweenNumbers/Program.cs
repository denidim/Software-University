using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string oPerator = Console.ReadLine();
            var sum = 0.0;
            var evenOdd = string.Empty;
            if (oPerator == "/")
            {
                sum = n1 / n2;
                if (n2 == 0 || n1 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {oPerator} {n2} = {sum:F2}");
                }
            }
            else if (oPerator == "%")
            {
                sum = n1 % n2;
                if (n2 == 0 || n1 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {oPerator} {n2} = {sum}");
                }
            }
            else if (oPerator == "+")
            {
                sum = n1 + n2;
                if (sum % 2 == 0)
                {
                    evenOdd = "even";
                }
                else if (sum % 2 != 0)
                {
                    evenOdd = "odd";
                }
                Console.WriteLine($"{n1} {oPerator} {n2} = {sum} - {evenOdd}");
            }
            else if (oPerator == "-")
            {
                sum = n1 - n2;
                if (sum % 2 == 0)
                {
                    evenOdd = "even";
                }
                else if (sum % 2 != 0)
                {
                    evenOdd = "odd";
                }
                Console.WriteLine($"{n1} {oPerator} {n2} = {sum} - {evenOdd}");
            }
            else if (oPerator == "*")
            {
                sum = n1 * n2;
                if (sum % 2 == 0)
                {
                    evenOdd = "even";
                }
                else if (sum % 2 != 0)
                {
                    evenOdd = "odd";
                }
                Console.WriteLine($"{n1} {oPerator} {n2} = {sum} - {evenOdd}");
            }
        }
    }
}

