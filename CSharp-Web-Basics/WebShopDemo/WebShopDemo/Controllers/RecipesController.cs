using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebShopDemo.Core.Models.Recipes;

namespace WebShopDemo.Controllers
{
    public class RecipesController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMemoryCache memoryCache;

        public RecipesController(
            IWebHostEnvironment webHostEnvironment,
            IMemoryCache memoryCache)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.memoryCache = memoryCache;
        }

        public IActionResult Add()
        {
            string[] ingredians = {"Meat","Pottato" };

            var model = new AddRecipeInputMopdel
            {
                Name = "YourName",
                RecipeType = Core.Data.Models.RecipeType.Unknow,
                FirstCooked = DateTime.UtcNow,
                Time = new RecipeTimeInputModel
                {
                    CookingTime = 10,
                    PreparationTime = 5,
                },
                Description = "YourAwesomeMeal",
                Ingredients = ingredians

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeInputMopdel inputModel)
        {
            if(inputModel.Image != null)
            {
                if (!inputModel.Image.FileName.EndsWith(".png"))
                {
                    this.ModelState.AddModelError(nameof(inputModel.Image), "Invalid file type.");
                }
                if (inputModel.Image.Length > 10 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image", "File too big");
                }
            }
            

            if (!ModelState.IsValid)
            {
                return View();
            }
            //TODO: Save data
            if(inputModel.Image != null)
            {
                using (FileStream fs = new FileStream(
                this.webHostEnvironment.WebRootPath + "/user.png", FileMode.Create))
                {
                    inputModel.Image.CopyToAsync(fs);
                }
            }
            

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult Image()
        {
            return this.PhysicalFile(this.webHostEnvironment.WebRootPath + "/user.png", "image/png");
        }

        public IActionResult Time()
        {
            // serch for the data in the memory cache
            if(!memoryCache.TryGetValue<DateTime>("Data", out var cacheTime))
            {
                // gets data from source
                cacheTime = GetData();

                // set data in the memory cache     // holds it for {time}
                memoryCache.Set("Data", cacheTime, TimeSpan.FromSeconds(10));
            }

            return this.Content(DateTime.Now.ToLongTimeString() + "-- Cache: " + cacheTime);
        }

        private DateTime GetData()
        {
            Thread.Sleep(5000);

            return DateTime.Now;
        }
    }
}
