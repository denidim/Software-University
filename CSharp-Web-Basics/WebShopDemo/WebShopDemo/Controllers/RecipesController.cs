using Microsoft.AspNetCore.Mvc;
using WebShopDemo.ModelBinders;

namespace WebShopDemo.Controllers
{
    public class RecipeTimeInputModel
    {
        public int PreparationTime { get; set; }


        public int CookingTime { get; set; }
        
    }

    public enum RecipeType
    {
        Unknow = 0,
        FastFood = 1,
        LongCookingMeal = 2,
    }

    public class AddRecipeInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RecipeType RecipeType { get; set; }

        public DateTime FirstCooked { get; set; }

        //[ModelBinder(typeof(ExtractYearModelBinder))]
        public int Year { get; set; }

        public RecipeTimeInputModel Time { get; set; }

        public string[] Ingredients { get; set; }
    }

    public class RecipesController : BaseController
    {
        public IActionResult Add(AddRecipeInputModel inputModel)
        {
            return this.Json(inputModel);
        }
    }
}
