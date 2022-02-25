using System;
using System.Linq;
using System.Collections.Generic;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsGrade = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!studentsGrade.ContainsKey(input[0]))
                {
                    studentsGrade.Add(input[0], new List<decimal>());
                    studentsGrade[input[0]].Add(decimal.Parse(input[1]));
                }
                else
                {
                    studentsGrade[input[0]].Add(decimal.Parse(input[1]));
                }
            }
            foreach (var item in studentsGrade)
            {
                Console.Write($"{item.Key:f2} -> ");

                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {item.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
