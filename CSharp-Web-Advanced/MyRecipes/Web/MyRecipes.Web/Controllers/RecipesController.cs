namespace MyRecipes.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;
    using System.Threading.Tasks;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipeService;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipesService recipeService)
        {
            this.categoriesService = categoriesService;
            this.recipeService = recipeService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
                return this.View();
            }

            await this.recipeService.CreateAsync(input);

            // TODO: Redirect to recipe info page
            return this.Redirect("/");
        }
    }
}
