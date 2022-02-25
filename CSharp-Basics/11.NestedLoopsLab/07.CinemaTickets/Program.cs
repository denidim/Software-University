using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int student = 0;
            int standard = 0;
            int kid = 0;
            int ticketsCount = 0;
            string movies = Console.ReadLine();
            while (movies != "Finish")
            {
                int seats = int.Parse(Console.ReadLine());
                int currentMovieTickets = 0;
                for (int i = 0; i < seats; i++)
                {
                    string type = Console.ReadLine();
                    if(type == "End")
                    {
                        break;
                    }

                    if (type == "standard")
                    {
                        standard++;
                    }
                    else if (type == "kid")
                    {
                        kid++; 
                    }
                    else if (type == "student")
                    {
                        student++;
                    }
                    ticketsCount++;
                    currentMovieTickets++;
                }
                double hallPercentage = (currentMovieTickets * 1.00 / seats * 1.00) * 100;
                Console.WriteLine($"{movies} - {hallPercentage:f2}% full.");
                movies = Console.ReadLine();
            }

            double studentP = (student * 1.00 / ticketsCount * 1.00) * 100;
            double standartP = (standard * 1.00 / ticketsCount * 1.00) * 100;
            double kidsP = (kid * 1.00 / ticketsCount * 1.00) * 100;
            Console.WriteLine($"Total tickets: {ticketsCount}");
            Console.WriteLine($"{studentP:f2}% student tickets.");
            Console.WriteLine($"{standartP:f2}% standard tickets.");
            Console.WriteLine($"{kidsP:f2}% kids tickets.");
        }
    }
}
