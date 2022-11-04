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
            Console.OutputEncoding = Encoding.UTF8;


            //var url = @"https://www.1001recepti.com/recipes/";

            var url = @"https://www.1001recepti.com/recipe/?recipe_id=2182323323323237-salata-s-kashu-i-sirene-bri";

            var config = Configuration.Default.WithDefaultLoader();

            var doc = await BrowsingContext.New(config).OpenAsync(url);

            GetCookingTime(doc);

            var categoriesNameAndUrl = GetCategories(doc); // category => all its recipes url

            foreach (var item in categoriesNameAndUrl)
            {
                var allRecipeDoc = await BrowsingContext.New(config).OpenAsync(item.Value);

                var allSelection = allRecipeDoc.QuerySelectorAll(".ss > a").OfType<IHtmlAnchorElement>();

                var recepieNameAndRecipeUrl = new Dictionary<string, string>();

                foreach (var currRecipe in allSelection)//recepi url
                {
                    var recepieUrl = currRecipe.GetAttribute("href");
                    Console.WriteLine(recepieUrl);

                    var currentRecipeDoc = await BrowsingContext.New(config).OpenAsync(recepieUrl);//null???

                    var name = GetRecipeName(currentRecipeDoc);

                    var products = GetProducts(currentRecipeDoc);

                    var recipe = GetRecipe(currentRecipeDoc);

                    var cookingTime = GetCookingTime(currentRecipeDoc);

                }
            }

        }

        private static string? GetCookingTime(IDocument currentRecipeDoc)
        {
            Console.WriteLine(currentRecipeDoc.QuerySelector("#rtime > span")?.TextContent);
            return currentRecipeDoc.QuerySelector("#rtime > span")?.TextContent;
        }

        private static string? GetRecipe(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelector(".recipe_step")?.TextContent;
        }

        private static Dictionary<string, string> GetProducts(IDocument currentRecipeDoc)
        {
            var quantity = currentRecipeDoc.QuerySelectorAll(".recipe_ingr > li > span > span");
            var products = currentRecipeDoc.QuerySelectorAll(".recipe_ingr > li > span > a");

            var productWithQuantity = new Dictionary<string, string>();

            for (int i = 0; i < quantity.Length; i++)
            {
                Console.WriteLine(products[i].TextContent);
                Console.WriteLine(quantity[i].TextContent);
                productWithQuantity[products[i].TextContent.ToString()] = quantity[i].TextContent ?? string.Empty;
            }

            return productWithQuantity;
        }

        private static Dictionary<string,string> GetCategories(IDocument doc)
        {
            var categoryName = doc.QuerySelectorAll("#cont_recipe_browse_big > div > a").OfType<IHtmlAnchorElement>();

            var result = new Dictionary<string, string>();

            foreach (var item in categoryName)
            {
                Console.WriteLine(item.TextContent);
                Console.WriteLine("Href = " + item.GetAttribute("href"));

                var recepieUrl = item.GetAttribute("href");

                result.Add(item.TextContent, recepieUrl);
            }

            return result;
        }


        private static string? GetRecipeName(IDocument doc)
        {
            return doc.QuerySelector(".box > article > h1")?.TextContent;
        }

        
    }
}

//Console.WriteLine("Serializing");
//Console.WriteLine(doc.ToHtml());

//Get recipe name

//Get Instructions

//Get Preparation Time

//Get Cooking Time

//Get Portions Count

//Get ImgUrl

//GetIngredients(doc);

//private static void GetIngredients(IDocument doc)
//{//needs url
//    var ingridients = doc.QuerySelectorAll(".recipe_ingr > li");

//    foreach (var item in ingridients)
//    {
//        Console.WriteLine(item.TextContent);
//        //Console.WriteLine(item.InnerHtml);
//        //Console.WriteLine(item.OuterHtml);
//        //Console.WriteLine(item.ToHtml());
//    }
//}