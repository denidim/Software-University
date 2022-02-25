using System.Collections.Generic;

namespace IteratorsAndComparators//library
{
    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IReadOnlyList<string> Authors { get; set; }


        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = new List<string>(authors);
        }

    }

}
