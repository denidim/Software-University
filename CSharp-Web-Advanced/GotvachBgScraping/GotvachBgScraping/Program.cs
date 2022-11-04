using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.Text;

namespace GotvachBgScraping
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //TODO: remove all console ouput!

            Console.OutputEncoding = Encoding.UTF8;

            var url = @"https://www.1001recepti.com/recipes/";

            var config = Configuration.Default.WithDefaultLoader();

            var doc = await BrowsingContext.New(config).OpenAsync(url);

            var categoriesNameAndUrl = GetCategories(doc); // category => all its recipes url

            foreach (var item in categoriesNameAndUrl) //item.key = CategoryName 
            {
                Console.WriteLine($"Category Name ====> {item.Key}");

                var allRecipeDoc = await BrowsingContext.New(config).OpenAsync(item.Value);

                // take first howmany???
                var allSelection = allRecipeDoc.QuerySelectorAll(".ss > a").OfType<IHtmlAnchorElement>().Take(100).ToList();

                for (int i = 0; i < allSelection.Count(); i++)
                {
                    var recepieUrl = allSelection[i].GetAttribute("href");

                    if (recepieUrl == null)
                    {
                        throw new Exception("RecipeUrl is null");
                    }

                    var currentRecipeDoc = await BrowsingContext.New(config).OpenAsync(recepieUrl);

                    var name = GetRecipeName(currentRecipeDoc);
                    Console.WriteLine(name);

                    var ingredients = GetIngredients(currentRecipeDoc);

                    foreach (var ingredient in ingredients)
                    {
                        Console.WriteLine($"{ingredient.Key} - {ingredient.Value}");
                    }

                    var instructions = GetInstructions(currentRecipeDoc);
                    Console.WriteLine(instructions);

                    var cookingTime = GetCookingTime(currentRecipeDoc);
                    Console.WriteLine(cookingTime);

                    var portinsCount = GetPortionsCount(currentRecipeDoc);
                    Console.WriteLine(portinsCount);

                    var imgSrc = GetImgSrc(currentRecipeDoc);
                    Console.WriteLine(imgSrc);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        private static string? GetPortionsCount(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelectorAll(".serv > .small > option")?.Where(x=>x.IsChecked())?.FirstOrDefault()?.TextContent;
        }

        private static string? GetImgSrc(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelector("#r1 > p > img")?.GetAttribute("src");
        }

        private static string? GetCookingTime(IDocument currentRecipeDoc)
        {
            Console.WriteLine(currentRecipeDoc.QuerySelector("#rtime > span")?.TextContent);

            return currentRecipeDoc.QuerySelector("#rtime > span")?.TextContent;
        }

        private static string? GetInstructions(IDocument currentRecipeDoc)
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
                productWithQuantity[products[i].TextContent.ToString()] = quantity[i].TextContent.ToString() ?? string.Empty;
            }

            return productWithQuantity;
        }
        

        private static string? GetRecipeName(IDocument doc)
        {
            return doc.QuerySelector(".box > article > h1")?.TextContent;
        }

        //gets all the categories with their name and url to page of all their recipes
        private static Dictionary<string, string> GetCategories(IDocument doc)
        {
            var categoryName = doc.QuerySelectorAll("#cont_recipe_browse_big > div > a").OfType<IHtmlAnchorElement>().ToList();

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

//foreach       foreach    getAllInfo
//categories => recipes => recipe

//Get recipe name

//Get Ingredients

//Get Instructions

//Get Preparation Time

//Get Cooking Time => only prep time available

//Get Portions Count

//Get ImgUrl
