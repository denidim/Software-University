using System;

namespace sumOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string[] strArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in strArr)
            {
                try
                {
                    sum += int.Parse(element);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
