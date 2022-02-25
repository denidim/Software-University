using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators//libraryIterator
{

    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {

            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly IList<Book> books;

            private int index = -1;

            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                return ++index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }

    }

    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IReadOnlyList<string> Authors { get; set; }


        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");

            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");

            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();

            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
