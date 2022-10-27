using Library.Models;
using Library.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await bookService.GetAllAsync();
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel()
            {
                Categories = await bookService.GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookService.AddBookAsync(model);

                return RedirectToAction(nameof(All));

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await bookService.AddBookToCollectionAsync(bookId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await bookService.GetMine(userId);

            return View(model);
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookService.RemoveFromCollectionAsync(bookId, userId);

            return RedirectToAction(nameof(Mine));
        }
    }
}
