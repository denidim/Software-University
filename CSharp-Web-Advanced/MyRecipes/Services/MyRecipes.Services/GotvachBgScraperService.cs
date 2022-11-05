namespace MyRecipes.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using AngleSharp.Dom;
    using AngleSharp.Html.Dom;

    public class GotvachBgScraperService : IGotvachBgScraperSevice
    {
        private readonly IConfiguration configuration;
        private readonly IBrowsingContext browsingContext;

        public GotvachBgScraperService()
        {
            this.configuration = Configuration.Default.WithDefaultLoader();

            this.browsingContext = BrowsingContext.New(this.configuration);
        }

        public async Task PopulateDbWithRecipes()
        {
            var url = @"https://www.1001recepti.com/recipes/";

            IDocument doc = await this.browsingContext.OpenAsync(url);

            Dictionary<string, string> categoriesNameAndUrl = GetCategories(doc);

            foreach (var item in categoriesNameAndUrl)
            {
                var allRecipeDoc = await this.browsingContext.OpenAsync(item.Value);

                List<IHtmlAnchorElement> allSelection = allRecipeDoc.QuerySelectorAll(".ss > a")
                    .OfType<IHtmlAnchorElement>().Take(100).ToList();

                for (int i = 0; i < allSelection.Count(); i++)
                {
                    var recepieUrl = allSelection[i].GetAttribute("href");

                    if (recepieUrl == null)
                    {
                        throw new Exception("RecipeUrl is null");
                    }

                    IDocument currentRecipeDoc = await this.browsingContext.OpenAsync(recepieUrl);

                    var name = GetRecipeName(currentRecipeDoc);
                    Console.WriteLine(name);

                    Dictionary<string, string> ingredients = GetIngredients(currentRecipeDoc);

                    string instructions = GetInstructions(currentRecipeDoc);

                    string cookingTime = GetCookingTime(currentRecipeDoc);

                    string portinsCount = GetPortionsCount(currentRecipeDoc);

                    string imgSrc = GetImgSrc(currentRecipeDoc);
                }
            }
        }

        private static string GetPortionsCount(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelectorAll(".serv > .small > option")?
                .Where(x => x.IsChecked())?.FirstOrDefault()?.TextContent;
        }

        private static string GetImgSrc(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelector("#r1 > p > img")?.GetAttribute("src");
        }

        private static string GetCookingTime(IDocument currentRecipeDoc)
        {
            Console.WriteLine(currentRecipeDoc.QuerySelector("#rtime > span")?.TextContent);

            return currentRecipeDoc.QuerySelector("#rtime > span")?.TextContent;
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

        private static string? GetRecipeName(IDocument doc)
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
