using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumDbContext context;

        public PostController(ForumDbContext _context)
        {
            context = _context;
        }


        public async Task<IActionResult> Index()
        {
            var model = await context.Posts
                .Where(x=>x.IsDeleted == false)
                .Select(x => new PostViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
                
            }).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddPostViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            context.Posts.Add(new Post()
            {
                Title = model.Title,
                Content = model.Content
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await context.Posts
                .Where(x => x.Id == id)
                .Select(x => new PostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content
                })
                .FirstOrDefaultAsync();

            if(post != null)
            {
                return View(post);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = await context.Posts.FindAsync(model.Id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.IsDeleted = true;

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
