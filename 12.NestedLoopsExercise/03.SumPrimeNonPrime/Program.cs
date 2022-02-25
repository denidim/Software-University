using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumPrime = 0;
            double sumNonPrime = 0;

            string command = Console.ReadLine();
            while (command != "stop")
            {
                double n = double.Parse(command);
                if (n < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    int count = 0;
                    for (int i = 1; i <= n; i++)
                    {
                        if (n % i == 0)
                        {
                            count++;
                        }
                    }
                    if (count == 2)
                    {
                        sumPrime += n;
                    }
                    else
                    {
                        sumNonPrime += n;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
