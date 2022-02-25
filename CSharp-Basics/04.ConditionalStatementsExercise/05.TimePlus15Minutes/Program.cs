using System;

namespace bonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var bonus = 0.0;
            if (num <= 100)
            {
                bonus = 5;
            }
            else if (num > 1000)//proverqvame ot nai-golqmoto kum nai-malkoto, zashtoto ako num>100(>100shte e True i, >1000nqma da se izpulni)!
            {
                bonus = (10.0 / 100) * num;
            }
            else if (num > 100)
            {
                bonus = (20.0 / 100) * num;
            }
            if (num % 2 == 0)
            {
                bonus = bonus + 1;
            }
            else if (num % 10 == 5)
            {
                bonus = bonus + 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(num + bonus);
        }
    }
}

