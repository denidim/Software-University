namespace MyRecipes.Services.Data
{
    using System;
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Web.ViewModels.Home;

    public class GetCountService : IGetCountsSerice
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepo;
        private readonly IRepository<Image> imagesRepo;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepo;
        private readonly IDeletableEntityRepository<Recipe> recipesRepo;

        public GetCountService(
            IDeletableEntityRepository<Category> categoriesRepo,
            IRepository<Image> imagesRepo,
            IDeletableEntityRepository<Ingredient> ingredientsRepo,
            IDeletableEntityRepository<Recipe> recipesRepo)
        {
            this.categoriesRepo = categoriesRepo;
            this.imagesRepo = imagesRepo;
            this.ingredientsRepo = ingredientsRepo;
            this.recipesRepo = recipesRepo;
        }

        IndexViewModel IGetCountsSerice.GetCounts()
        {
            var data = new IndexViewModel
            {
                CategoriesCount = this.categoriesRepo.All().Count(),
                ImagesCount = this.imagesRepo.All().Count(),
                IngredientsCount = this.ingredientsRepo.All().Count(),
                RecipesCount = this.recipesRepo.All().Count(),
            };

            return data;
        }
    }
}
