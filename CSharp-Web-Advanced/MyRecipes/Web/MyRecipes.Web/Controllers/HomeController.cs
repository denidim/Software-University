namespace MyRecipes.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels;
    using MyRecipes.Web.ViewModels.Home;

    // 1. ApplicationDbContext
    // 2. Repositories
    // 3. Services
    public class HomeController : BaseController
    {
        private readonly IGetCountsSerice getCountsSerice;
        private readonly IRecipesService recipesService;

        public HomeController(
            IGetCountsSerice getCountsSerice,
            IRecipesService recipesService)
        {
            this.getCountsSerice = getCountsSerice;
            this.recipesService = recipesService;
        }

        public IActionResult Index()
        {
            var counts = this.getCountsSerice.GetCounts();

            var viewModel = new IndexViewModel
            {
                CategoriesCount = counts.CategoriesCount,
                ImagesCount = counts.ImagesCount,
                IngredientsCount = counts.IngredientsCount,
                RecipesCount = counts.RecipesCount,
                RandomRecipes = this.recipesService.GetRandom<IndexPageRecipeViewModel>(10),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
