
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace IteratorsAndComparators//bookComparer
{

    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books,new BookComparator());
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

    public class BookComparator : IComparer<Book>
    {

        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);

            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);
            }

            return result;
        }
    }

    public class Book : IComparable<Book>
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

        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");

            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");

            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
        }
    }
}
