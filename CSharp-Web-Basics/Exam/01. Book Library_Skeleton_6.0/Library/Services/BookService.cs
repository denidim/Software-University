using Library.Data;
using Library.Data.Models;
using Library.Models;
using Library.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext db;

        public BookService(LibraryDbContext _db)
        {
            db=_db;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var entity = new Book()
            {
                Author = model.Author,
                Description =model.Description,
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await db.Books.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var user = await db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var book = await db.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (!user.ApplicationUsersBooks.Any(b => b.BookId == bookId))
            {
                user.ApplicationUsersBooks
                    .Add(new ApplicationUserBook { ApplicationUserId = userId, BookId = bookId });
            }

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllBooksViewModel>> GetAllAsync()
        {
            return await db.Books.Select(b => new AllBooksViewModel()
            {
                Id = b.Id,
                ImageUrl = b.ImageUrl,
                Title = b.Title,
                Author = b.Author,
                Rating = b.Rating,
                Description = b.Description,
                Category = b.Category.Name,
            }).ToListAsync();

        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<IEnumerable<AllBooksViewModel>> GetMine(string userId)
        {
            var user = await db.Users
               .Where(u => u.Id == userId)
               .Include(u => u.ApplicationUsersBooks)
               .ThenInclude(ub => ub.Book)
               .ThenInclude(b => b.Category)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            return user.ApplicationUsersBooks.Select(x => new AllBooksViewModel()
            {
                Author = x.Book.Author,
                Category = x.Book.Category.Name,
                Id = x.BookId,
                ImageUrl = x.Book.ImageUrl,
                Title = x.Book.Title,
                Rating = x.Book.Rating
            });
        }


        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var user = await db.Users
               .Where(u => u.Id == userId)
               .Include(u => u.ApplicationUsersBooks)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var movie = user.ApplicationUsersBooks.FirstOrDefault(b => b.BookId == bookId);

            if (movie != null)
            {
                user.ApplicationUsersBooks.Remove(movie);

                await db.SaveChangesAsync();
            }
        }
    }
}
