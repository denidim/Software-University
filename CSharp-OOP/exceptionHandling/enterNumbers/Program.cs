using System;
using System.Collections.Generic;

namespace enterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            const int start = 1;
            const int end = 100;
            ReadNumber(start, end);
        }
        public static void ReadNumber(int start,int end)
        {
            List<int> numbers = new List<int>();
            while (numbers.Count < 10)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());

                    if (n <= start || n >= end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    if (numbers.Count == 0)
                    {
                        numbers.Add(n);
                    }
                    else
                    {
                        if (n > numbers[numbers.Count - 1])
                        {
                            numbers.Add(n);
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"Your number is not in range {start} - 100!");
                    }
                    else
                    {
                        Console.WriteLine($"Your number is not in range {numbers[numbers.Count - 1]} - 100!");
                    }
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
