namespace MyRecipes.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using AngleSharp.Dom;
    using AngleSharp.Html.Dom;
    using Microsoft.EntityFrameworkCore;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;

    public class RecipeScraperService : IRecipeScraperSevice
    {
        private readonly IConfiguration configuration;
        private readonly IBrowsingContext browsingContext;

        private readonly ICollection<RecipeDto> allRecipes;

        private readonly IDeletableEntityRepository<Category> categoryRepo;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepo;
        private readonly IDeletableEntityRepository<Recipe> recipeRepo;

        public RecipeScraperService(
            IDeletableEntityRepository<Category> categoryRepo,
            IDeletableEntityRepository<Ingredient> ingredientRepo,
            IDeletableEntityRepository<Recipe> recipeRepo)
        {
            this.configuration = Configuration.Default.WithDefaultLoader();
            this.browsingContext = BrowsingContext.New(this.configuration);

            this.allRecipes = new List<RecipeDto>();

            this.categoryRepo = categoryRepo;
            this.ingredientRepo = ingredientRepo;
            this.recipeRepo = recipeRepo;
        }

        public async Task PopulateDtoWithRecipesAsync()
        {
            var url = @"https://www.1001recepti.com/recipes/";

            IDocument doc = await this.browsingContext.OpenAsync(url);

            Dictionary<string, string> categoriesNameAndUrl = GetCategories(doc);

            foreach (var item in categoriesNameAndUrl)
            {
                var allRecipeDoc = await this.browsingContext.OpenAsync(item.Value);

                List<IHtmlAnchorElement> allSelection = allRecipeDoc.QuerySelectorAll(".ss > a")
                    .OfType<IHtmlAnchorElement>().Take(5).ToList();

                // here we add all recipes into new recipe dto
                for (int i = 0; i < allSelection.Count(); i++)
                {
                    var recepieUrl = allSelection[i].GetAttribute("href");

                    if (recepieUrl == null)
                    {
                        throw new Exception("RecipeUrl is null");
                    }

                    var recipe = new RecipeDto();

                    recipe.OriginalUrl = recepieUrl;

                    var categoryName = item.Key;
                    recipe.CategoryName = categoryName;

                    IDocument currentRecipeDoc = await this.browsingContext.OpenAsync(recepieUrl);

                    var name = GetRecipeName(currentRecipeDoc);
                    recipe.Name = name;

                    Dictionary<string, string> ingredients = GetIngredients(currentRecipeDoc);
                    recipe.IngridientsAndQuantity = ingredients;

                    string instructions = GetInstructions(currentRecipeDoc);
                    recipe.Instructions = instructions;

                    int cookingTime = GetCookingTime(currentRecipeDoc);
                    recipe.CookingTime = TimeSpan.FromMinutes(cookingTime);

                    int portinsCount = GetPortionsCount(currentRecipeDoc);
                    recipe.PortionCount = portinsCount;

                    string imgSrc = GetImgSrc(currentRecipeDoc);
                    recipe.Image = imgSrc;

                    string extension = "No Image";

                    if (imgSrc != null)
                    {
                        int index = imgSrc.LastIndexOf('.');
                        if (index < imgSrc.Length - 1)
                        {
                            extension = imgSrc.Substring(index);
                        }

                        if (extension == null || extension.Length < 3)
                        {
                            extension = "No Image";
                        }
                    }

                    recipe.ImageExtension = extension;

                    this.allRecipes.Add(recipe);
                }
            }

            await this.PopulateDb(this.allRecipes);
        }

        private async Task PopulateDb(ICollection<RecipeDto> allRecipes)
        {
            foreach (var inputRecipe in allRecipes)
            {
                var categoryId = await this.GetOrCreateCategoryAsync(inputRecipe.CategoryName);

                var ingredientsIdsAndQuantity = await this
                    .GetOrCreateIngredientsAsync(inputRecipe.IngridientsAndQuantity);

                bool recipeExists = await this.recipeRepo
                    .AllAsNoTracking()
                    .AnyAsync(x => x.Name == inputRecipe.Name);

                if (recipeExists)
                {
                    continue;
                }

                var recipe = new Recipe()
                {
                    Name = inputRecipe.Name,
                    Instructions = inputRecipe.Instructions,
                    PreparationTime = TimeSpan.FromMinutes(0),
                    CookingTime = inputRecipe.CookingTime,
                    PortionCount = inputRecipe.PortionCount,
                    OriginalUrl = inputRecipe.OriginalUrl,
                    CategoryId = categoryId,
                    CreatedOn = DateTime.UtcNow,
                };

                foreach (var item in ingredientsIdsAndQuantity)
                {
                    RecipeIngredient recipeIngredient = new RecipeIngredient
                    {
                        RecipeId = recipe.Id,
                        IngredientId = item.Key,
                        Quantity = item.Value,
                    };

                    recipe.Ingredients.Add(recipeIngredient);
                }

                var image = new Image
                {
                    RecipeId = recipe.Id,
                    Extension = inputRecipe.ImageExtension,
                };

                recipe.Images.Add(image);

                await this.recipeRepo.AddAsync(recipe);
                await this.recipeRepo.SaveChangesAsync();

            }
        }


        private async Task<Dictionary<int, string>> GetOrCreateIngredientsAsync(Dictionary<string, string> ingridientsAndQunantity)
        {
            var ingrIdsAndQuantity = new Dictionary<int, string>();

            Ingredient ingredient;

            foreach (var keyValuePairs in ingridientsAndQunantity)
            {
                var ingredientName = keyValuePairs.Key;
                var ingredientQuantity = keyValuePairs.Value;

                ingredient = await this.ingredientRepo
                            .AllAsNoTracking()
                            .FirstOrDefaultAsync(x => x.Name == ingredientName);

                if (ingredient == null)
                {
                    ingredient = new Ingredient
                    {
                        Name = ingredientName,
                    };

                    await this.ingredientRepo.AddAsync(ingredient);
                    await this.ingredientRepo.SaveChangesAsync();
                }

                ingrIdsAndQuantity[ingredient.Id] = ingredientQuantity;
            }

            return ingrIdsAndQuantity;
        }

        private async Task<int> GetOrCreateCategoryAsync(string categoryName)
        {
            Category category = await this.categoryRepo
                                .AllAsNoTracking()
                                .FirstOrDefaultAsync(x => x.Name == categoryName);

            if (category == null)
            {
                category = new Category()
                {
                    Name = categoryName,
                };

                await this.categoryRepo.AddAsync(category);
                await this.categoryRepo.SaveChangesAsync();
            }

            return category.Id;
        }

        private static int GetPortionsCount(IDocument currentRecipeDoc)
        {
            int count = 0;

            string value = currentRecipeDoc.QuerySelectorAll(".serv > .small > option")?
                .Where(x => x.IsChecked())?.FirstOrDefault()?.TextContent;

            if (value != null)
            {
                count = int.Parse(value);
            }

            return count;
        }

        private static string GetImgSrc(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelector("#r1 > p > img")?.GetAttribute("src") ?? string.Empty;
        }

        private static int GetCookingTime(IDocument currentRecipeDoc)
        {
            int cookingTime = 0;

            string time = currentRecipeDoc?.QuerySelector("#rtime > span")?.TextContent;

            int index = time.IndexOf(' ');

            var newTime = time.Substring(0, index);

            if (newTime != null && time != null)
            {
                cookingTime = int.Parse(newTime);
            }

            return cookingTime;
        }

        private static string GetInstructions(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelector(".recipe_step")?.TextContent.TrimStart();
        }

        private static Dictionary<string, string> GetIngredients(IDocument currentRecipeDoc)
        {
            var products = currentRecipeDoc.QuerySelectorAll(".recipe_ingr > li > span > a");

            var quantity = currentRecipeDoc.QuerySelectorAll(".recipe_ingr > li > span > span");

            var productWithQuantity = new Dictionary<string, string>();

            for (int i = 0; i < products.Length; i++)
            {
                productWithQuantity[products[i].TextContent.ToString()]
                    = quantity[i].TextContent.ToString() ?? string.Empty;
            }

            return productWithQuantity;
        }

        private static string GetRecipeName(IDocument doc)
        {
            return doc.QuerySelector(".box > article > h1")?.TextContent;
        }

        // gets all the categories with their name and url to page of all their recipes
        private static Dictionary<string, string> GetCategories(IDocument doc)
        {
            var categoryName = doc.QuerySelectorAll("#cont_recipe_browse_big > div > a")
                .OfType<IHtmlAnchorElement>().ToList();

            var result = new Dictionary<string, string>();

            for (int i = 0; i < categoryName.Count(); i++)
            {
                var recepieUrl = categoryName[i].GetAttribute("href") ?? string.Empty;

                result.Add(categoryName[i].TextContent, recepieUrl);
            }

            return result;
        }
    }
}
