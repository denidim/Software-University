using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Models.Recipes;

namespace WebShopDemo.Controllers
{
    public class RecipesController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public RecipesController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
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
        
    }
}
