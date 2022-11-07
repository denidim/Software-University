namespace MyRecipes.Web.ViewModels.Recipes
{
    public class RecipeInListViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public int Title { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
