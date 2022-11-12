namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipeService : IRecipesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Recipe> recipesRepo;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepo;

        public RecipeService(
            IDeletableEntityRepository<Recipe> recipesRepo,
            IDeletableEntityRepository<Ingredient> ingredientRepo)
        {
            this.recipesRepo = recipesRepo;
            this.ingredientRepo = ingredientRepo;
        }

        public async Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath)
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

            Directory.CreateDirectory($"{imagePath}/recipes/");

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                recipe.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/recipes/{dbImage.Id}.{extension}";

                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
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

        public T GetById<T>(int id)
        {
            var recipe = this.recipesRepo.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return recipe;
        }

        public IEnumerable<T> GetByIngredients<T>(IEnumerable<int> ingredientIds)
        {
            var query = this.recipesRepo.All().AsQueryable();

            foreach (var ingredientId in ingredientIds)
            {
                query = query.Where(x => x.Ingredients.Any(i => i.IngredientId == ingredientId));
            }

            return query.To<T>().ToList();
        }

        public int GetCount()
        {
            return this.recipesRepo.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            // =>                                Random sort
            return this.recipesRepo.All().OrderBy(x => Guid.NewGuid())
                .Take(count)
                .To<T>().ToList();
        }

        public async Task UpdateAsync(int id, EditRecipeInputModel input)
        {
            var recipe = this.recipesRepo.All().FirstOrDefault(x => x.Id == id);

            recipe.Name = input.Name;
            recipe.Instructions = input.Instructions;
            recipe.CookingTime = TimeSpan.FromMinutes(input.CookingTime);
            recipe.PreparationTime = TimeSpan.FromMinutes(input.PreparationTime);
            recipe.PortionCount = input.PortionCount;
            recipe.CategoryId = input.CategoryId;

            await this.recipesRepo.SaveChangesAsync();
        }
    }
}
