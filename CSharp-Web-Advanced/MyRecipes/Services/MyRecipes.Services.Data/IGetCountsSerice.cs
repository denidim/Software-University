namespace MyRecipes.Services.Data
{
    using MyRecipes.Services.Data.DTOs;
    using MyRecipes.Web.ViewModels.Home;

    public interface IGetCountsSerice
    {
        // 1. Use View Model
        // 2. Create DTO -> view model
        CountsDto GetCounts();
    }
}
