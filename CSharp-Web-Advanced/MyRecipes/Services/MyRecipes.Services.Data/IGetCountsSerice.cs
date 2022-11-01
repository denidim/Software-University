namespace MyRecipes.Services.Data
{
    using MyRecipes.Web.ViewModels.Home;

    public interface IGetCountsSerice
    {
        // 1. User View Model
        IndexViewModel GetCounts();
    }
}
