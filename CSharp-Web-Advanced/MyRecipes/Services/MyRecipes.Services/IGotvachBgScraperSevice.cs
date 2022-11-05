using System.Threading.Tasks;

namespace MyRecipes.Services
{
    public interface IGotvachBgScraperSevice
    {
        Task PopulateDtoWithRecipes();
    }
}
