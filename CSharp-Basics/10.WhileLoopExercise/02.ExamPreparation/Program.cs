using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badScore = int.Parse(Console.ReadLine());
            int counter = 0;
            double scoreSum = 0;
            int counterScore = 0;//scoreSum/counterScore
            bool enough = false;
            string lastName = "";
            while (badScore != counter)
            {
                string name = Console.ReadLine();
                if (name == "Enough")
                {
                    enough = true;
                    break;
                }
                lastName = name;
                int score = int.Parse(Console.ReadLine());
                if (score <= 4)
                {
                    counter++;
                }
                scoreSum += score;
                counterScore++;
            }
            if (enough == true)
            {
                Console.WriteLine($"Average score: {scoreSum / counterScore:f2}");
                Console.WriteLine($"Number of problems: {counterScore}");
                Console.WriteLine($"Last problem: {lastName}");
            }
            else
            {
                Console.WriteLine($"You need a break, {counter} poor grades.");
            }
        }
    }
}
