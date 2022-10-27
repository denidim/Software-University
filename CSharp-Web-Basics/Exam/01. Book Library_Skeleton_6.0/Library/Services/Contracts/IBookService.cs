using Library.Data.Models;
using Library.Models;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBooksViewModel>> GetAllAsync();

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task AddBookToCollectionAsync(int bookId, string userId);

        Task<IEnumerable<AllBooksViewModel>> GetMine(string userId);

        Task RemoveFromCollectionAsync(int bookId, string userId);
    }
}
