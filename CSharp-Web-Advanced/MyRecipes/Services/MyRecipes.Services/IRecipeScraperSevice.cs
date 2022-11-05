namespace MyRecipes.Services
{
    using System.Threading.Tasks;

    public interface IRecipeScraperSevice
    {
        Task PopulateDtoWithRecipesAsync();
    }
}
