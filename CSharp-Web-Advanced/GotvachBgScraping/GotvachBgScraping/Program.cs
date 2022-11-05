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
            //TODO: remove all console ouput before use!

            Console.OutputEncoding = Encoding.UTF8;

            var url = @"https://www.google.com/maps/place/VetCare/@42.6725107,23.3109149,17z/data=!3m1!4b1!4m6!3m5!1s0x40aa84fdb7f81df5:0xbdd16cf05e740dae!8m2!3d42.6725044!4d23.3109027!16s%2Fg%2F1pp2tzppw?authuser=0&hl=en";

            var config = Configuration.Default.WithDefaultLoader();

            var doc = await BrowsingContext.New(config).OpenAsync(url);

            //#QA0Szd > div > div > div.w6VYqd > div.bJzME.tTVLSc > div > div.e07Vkf.kA9KIf > div > div > div:nth-child(7) > div.OqCZI.fontBodyMedium.WVXvdc > div.OMl5r.hH0dDd.jBYmhd > div.MkV9 > div.o0Svhf > span.ZDu9vd > span:nth-child(1) > span:nth-child(2)
            var value = doc.QuerySelectorAll("#QA0Szd > div > div > div.w6VYqd > div.bJzME.tTVLSc > div > div.e07Vkf.kA9KIf > div > div > div.TIHn2 > div.tAiQdd > div.lMbq3e > div:nth-child(1) > h1");
            foreach (var item in value)
            {
                Console.WriteLine(item.TextContent);
            }


            var categoriesNameAndUrl = GetCategories(doc); // category => all its recipes url

            foreach (var item in categoriesNameAndUrl) //item.key = CategoryName 
            {
                var allRecipeDoc = await BrowsingContext.New(config).OpenAsync(item.Value);

                // take first howmany???
                var allSelection = allRecipeDoc.QuerySelectorAll(".ss > a").OfType<IHtmlAnchorElement>().Take(100).ToList();

                for (int i = 0; i < allSelection.Count(); i++)
                {
                    Console.WriteLine($"Category Name [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]====> {item.Key}");

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

                    string extension = string.Empty;
                    if(imgSrc != null)
                    {
                        int index = imgSrc.LastIndexOf('.');
                        extension = imgSrc.Substring(index);
                    }

                    var imgExstension = extension;
                    Console.WriteLine(imgExstension);


                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(i);
                }
            }
        }

        private static int GetPortionsCount(IDocument currentRecipeDoc)
        {
            int count = 0;

            string? value = currentRecipeDoc.QuerySelectorAll(".serv > .small > option")?
                .Where(x => x.IsChecked())?.FirstOrDefault()?.TextContent;

            if(value != null)
            {
                count = int.Parse(value);
            }

            return count;
        }

        private static string? GetImgSrc(IDocument currentRecipeDoc)
        {
            return currentRecipeDoc.QuerySelector("#r1 > p > img")?.GetAttribute("src");
        }

        private static int GetCookingTime(IDocument currentRecipeDoc)
        {
            int cookingTime = 0;

            string? time = currentRecipeDoc?.QuerySelector("#rtime > span")?.TextContent;

            int index = time.IndexOf(' ');

            var newTime = time.Substring(0, index);

            if (newTime != null && time != null)
            {
                cookingTime = int.Parse(newTime);
            }

            return cookingTime;
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
