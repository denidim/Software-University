namespace MyRecipes.Web.ViewModels.Recipes
{
    using System.Linq;

    using AutoMapper;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class RecipeInListViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, RecipeInListViewModel>()
                .ForMember(x => x.ImageUrl, options =>
                options.MapFrom(x =>
                x.Images.FirstOrDefault().ImageUrl != null ?
                    x.Images.FirstOrDefault().ImageUrl :
                    "/images/recipes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
