namespace MyRecipes.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Web.ViewModels.Recipes;

    public class CreateRecipeService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepo;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepo;

        public CreateRecipeService(
            IDeletableEntityRepository<Recipe> recipesRepo,
            IDeletableEntityRepository<Ingredient> ingredientRepo)
        {
            this.recipesRepo = recipesRepo;
            this.ingredientRepo = ingredientRepo;
        }

        public async Task CreateAsync(CreateRecipeInputModel input)
        {
            var recipe = new Recipe()
            {
                CategoryId = input.CategoryId,
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                Instructions = input.Instructions,
                Name = input.Name,
                PortionCount = input.PortionCount,
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
    }
}
