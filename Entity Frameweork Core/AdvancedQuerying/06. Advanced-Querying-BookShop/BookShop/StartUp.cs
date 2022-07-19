namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetMostRecentBooks(db));
        }

        public static int RemoveBooks(BookShopContext db)
        {
            /*16.Remove Books 
             * Remove all books, which have less than 4200 copies.
             * Return an int - the number of books that were deleted from the database. */

            var books = db.Books.Where(x => x.Copies < 4200).ToList();

            db.Books.RemoveRange(books);

            db.SaveChanges();

            return books.Count;

        }

        public static void IncreasePrices(BookShopContext db)
        {
            /*Increase the prices of all books released before 2010 by 5. */

            var books = db.Books.Where(x => x.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            db.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext db)
        {
            /*14. Most Recent Books 
             * Get the most recent books by categories. 
             * The categories should be ordered by name alphabetically. 
             * Only take the top 3 most recent books from each category 
             * - ordered by release date (descending).
             * Select and print the category name and for each book 
             * – its title and release year. */

            var categories = db.Categories
                .OrderBy(c => c.Name)
                .Select(x => new
                {
                    x.Name,
                    title = x.CategoryBooks
                    .OrderByDescending(x => x.Book.ReleaseDate)
                    .Take(3)
                    .Select(x => new
                    {
                        bookTitle = x.Book.Title,
                        bookreleseDate = x.Book.ReleaseDate
                    })
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var titleList in category.title)
                {
                    sb.AppendLine($"{titleList.bookTitle} ({titleList.bookreleseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            /*13.Profit by Category 
             * Return the total profit of all books by category. 
             * Profit for a book can be calculated by multiplying its number of copies by the price per single book.
             * Order the results by descending by total profit for a category
             * and ascending by category name.*/

            var categories = db.Categories
                .Select(x => new
                {
                    x.Name,
                    total = x.CategoryBooks
                        .Select(x=>x.Book)
                        .Sum(x=>x.Copies * x.Price)
                })
                .OrderByDescending(x => x.total)
                .ThenBy(x => x.Name)
                .ToList();

            return string.Join(Environment.NewLine, categories.Select(x => $"{x.Name} ${x.total:f2}"));
        }

        public static string CountCopiesByAuthor(BookShopContext db)
        {
            /*12.Total Book Copies 
             * Return the total number of book copies for each author. Order the results descending by total book copies.
             * Return all results in a single string, each on a new line. */

            var authors = db.Authors
                .Select(x => new
                {
                    fullName = $"{x.FirstName} {x.LastName}",
                    copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x=>x.copies)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x => $"{x.fullName} - {x.copies}"));
        }

        public static int CountBooks(BookShopContext db, int length)
        {
            /*11.Count Books 
             * Return the number of books, which have a title longer than the number given as an input.*/

            var books = db.Books.Count(x => x.Title.Length > length);
            return books;
        }

        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            /*10. Book Search by Author 
             * Return all titles of books and their authors' names for books,
             * which are written by authors whose last names start with the given string.
             * Return a single string with each title on a new row.
             * Ignore casing. Order by book id ascending.*/

            var books = db.Books
                .OrderBy(x => x.BookId)
                .Where(x => EF.Functions.Like(x.Author.LastName,$"{input}%"))
                .Select(x => new
                {
                    x.Title,
                    authorName = $"{x.Author.FirstName} {x.Author.LastName}",
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.authorName})"));
        }

        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {
            /* 9.Book Search
             * Return the titles of the book, which contain a given string. Ignore casing.
             * Return all titles in a  single string, each on a new row ordered alphabetically.*/

            var titles = db.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, titles.Select(x => x));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext db, string chars)
        {
            /* 8. Author Search
             * Return the full names of authors, whose first name ends with a given string.
             * Return all names in a single string, each on a new row ordered alphabetically.*/

            var authors = db.Authors
                .Where(x=>x.FirstName.EndsWith(chars))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x=>x.FirstName)
                .ThenBy(x=>x.LastName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x => $"{x.FirstName} {x.LastName}"));
        }

        public static string GetBooksReleasedBefore(BookShopContext db, string date)
        {
            /*7. Released Before Date 
             * Return the title, edition type and price of all books that are released before a given date.
             * The date will be a string in the format dd-MM-yyyy.
             * Return all of the rows in a single string, ordered by release date descending.*/

            var books = db.Books
                .Where(x => x.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy",CultureInfo.InvariantCulture))
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));
        }

        public static string GetBooksByCategory(BookShopContext db, string input)
        {
            /* 6. Book Titles by Category
             Return in a single string the titles of books by a given list of categories.
             The list of categories will be given in a single line separated by one or more spaces.
             Ignore casing. Order by title alphabetically.*/

            var categories = input.ToLower().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            var books = db.Books
                .Where(b => b.BookCategories
                .Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(x => x));
        }

        public static string GetBooksNotReleasedIn(BookShopContext db,int year)
        {
            /* 5. Not Released In 
             * Return in a single string with all titles of books that are NOT released in a given year.
             * Order them by book id ascending. */

            var books = db.Books
                .Where(x=>x.ReleaseDate.HasValue 
                        && x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext db)
        {
            /*4. Books by Price
             * Return in a single string all titles and prices of books with a price higher than 40, 
             * each on a new row in the format given below. Order them by price descending.*/

            var books = db.Books
                .Where(x => x.Price > 40)
                .Select(x => new {x.Title,x.Price})
                .OrderByDescending(x=>x.Price)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(x=>$"{x.Title} - ${x.Price}"));
        }

        public static string GetGoldenBooks(BookShopContext db)
        {
            /*3. Golden Books 
             * Return in a single string title of the golden edition books that have less than 5000 copies,
             * each on a new line. Order them by book id ascending.*/

            var book = db.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies<5000)
                .Select(x => new { x.Title,x.BookId })
                .OrderBy(x => x.BookId)
                .ToList();

            return string.Join(Environment.NewLine,book.Select(x=>x.Title));
        }

        public static string GetBooksByAgeRestriction(BookShopContext db,string command)
        {
            /* 2. Age Restriction
             Return in a single string all book titles, each on a new line, 
             that have an age restriction, equal to the given command. Order the titles alphabetically.
             Read input from the console in your main method and call your method with the necessary arguments.
             Print the returned string to the console. Ignore the casing of the input.*/

            var sb = new StringBuilder();

            var age = Enum.Parse<AgeRestriction>(command, true);

            var titles = db.Books
                .Where(x => x.AgeRestriction == age)
                .Select(x=>x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
