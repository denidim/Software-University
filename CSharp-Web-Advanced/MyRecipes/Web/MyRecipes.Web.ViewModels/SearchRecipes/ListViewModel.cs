namespace MyRecipes.Web.ViewModels.SearchRecipes
{
    using System.Collections.Generic;

    using MyRecipes.Web.ViewModels.Recipes;

    public class ListViewModel
    {
        public IEnumerable<RecipeInListViewModel> Recipes { get; set; }
    }
}
