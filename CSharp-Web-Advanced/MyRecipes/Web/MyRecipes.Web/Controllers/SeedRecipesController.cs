namespace MyRecipes.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services;

    // TODO: Move to administration area
    public class SeedRecipesController : Controller
    {
        private readonly IRecipeScraperSevice recipeScraperSevice;

        public SeedRecipesController(IRecipeScraperSevice recipeScraperSevice)
        {
            this.recipeScraperSevice = recipeScraperSevice;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Seed()
        {
            await this.recipeScraperSevice.PopulateDtoWithRecipesAsync();

            return this.View();
        }
    }
}
