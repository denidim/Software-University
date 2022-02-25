using System;

namespace _08.GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int stopper = 0;
            int suspended = 0;
            double totalGrade = 0;

            while (stopper < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    suspended++;
                }
                if (suspended > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {stopper} grade");
                    break;
                }
                totalGrade += grade;
                stopper++;
            }
            if(suspended < 1)
            {
                Console.WriteLine($"{name} graduated. Average grade: {totalGrade/12:f2}");
            }
        }
    }
}
