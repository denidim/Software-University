namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class IngredientsService : IIngredientsService
    {
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepo;

        public IngredientsService(IDeletableEntityRepository<Ingredient> ingredientsRepo)
        {
            this.ingredientsRepo = ingredientsRepo;
        }

        public IEnumerable<T> GetAllPopular<T>()
        {
            return this.ingredientsRepo.All()
                .Where(x => x.Recipes.Count() >= 20)
                .OrderByDescending(x => x.Recipes.Count())
                .To<T>()
                .ToList();
        }
    }
}
