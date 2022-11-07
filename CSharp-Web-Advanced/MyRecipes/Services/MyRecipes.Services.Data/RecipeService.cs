namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipeService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepo;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepo;

        public RecipeService(
            IDeletableEntityRepository<Recipe> recipesRepo,
            IDeletableEntityRepository<Ingredient> ingredientRepo)
        {
            this.recipesRepo = recipesRepo;
            this.ingredientRepo = ingredientRepo;
        }

        public async Task CreateAsync(CreateRecipeInputModel input, string userId)
        {
            var recipe = new Recipe()
            {
                CategoryId = input.CategoryId,
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                Instructions = input.Instructions,
                Name = input.Name,
                PortionCount = input.PortionCount,
                CreatedByUserId = userId,
            };

            foreach (var inputIngredient in input.Ingredients)
            {
                var ingredient = await this.ingredientRepo
                    .All()
                    .FirstOrDefaultAsync(x => x.Name == inputIngredient.IngredientName);

                if (ingredient == null)
                {
                    ingredient = new Ingredient { Name = inputIngredient.IngredientName };
                }

                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = inputIngredient.Quantity,
                });
            }

            await this.recipesRepo.AddAsync(recipe);
            await this.recipesRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var recipes = this.recipesRepo.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();

            return recipes;

            // 1-12 page 1
            // 13-24 page 2
            // 25-36 page 3
        }

        public int GetCount()
        {
            return this.recipesRepo.AllAsNoTracking().Count();
        }
    }
}
