using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            string nextBook = Console.ReadLine();
            bool noFound = true;
            int counter = 0;
            while (nextBook != "No More Books")
            {
                string book = nextBook;
                if (nextBook == favoriteBook)
                {
                    noFound = false;
                    break;
                }
                counter++;
                nextBook = Console.ReadLine();
            }
            if (noFound == true)
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
            else
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
