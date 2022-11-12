namespace MyRecipes.Web.ViewModels.SearchRecipes
{
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class IngredientNameIdViewModel : IMapFrom<Ingredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
