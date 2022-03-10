using System;
using System.Collections.Generic;
using System.Text;

namespace cards
{
    public class InvalidCardException : ApplicationException
    {
        private const string message = "Invalid card!";

        public InvalidCardException() : base(message)
        {
        }
    }

    public class Card
    {
        private readonly List<string> faces = new List<string>{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly List<string> suts = new List<string> { "S", "H", "D", "C" };

        public string CreateCard(string face, string suit)
        {
            StringBuilder sb = new StringBuilder();

            if(faces.Contains(face) && suts.Contains(suit))
            {
                char ch = new char();
                if (suit == "S")
                {
                    ch = '\u2660';
                }
                if (suit == "H")
                {
                    ch = '\u2665';
                }
                if (suit == "D")
                {
                    ch = '\u2666';
                }
                if (suit == "C")
                {
                    ch = '\u2663';
                }

                sb.AppendLine($"[{face}{ch}]");
            }
            else
            {
                throw new InvalidCardException();
            }

            return sb.ToString().TrimEnd();
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card();
            string[] strArr = Console.ReadLine()
                .Split(',',' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < strArr.Length; i++)
            {
                string[] pair = strArr[i].Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string str = "";
                try
                {
                    str = card.CreateCard(pair[0], pair[1]);
                    if (str.Length <= 5)
                    {
                        sb.Append($"{str} ");
                    }
                }
                catch (InvalidCardException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(sb.ToString().TrimEnd()); ;
        }
    }
}
