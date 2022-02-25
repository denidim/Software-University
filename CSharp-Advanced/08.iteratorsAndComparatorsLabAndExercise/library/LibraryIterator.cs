using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators//library
{
    public class LibraryIterator : IEnumerator<Book>
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
