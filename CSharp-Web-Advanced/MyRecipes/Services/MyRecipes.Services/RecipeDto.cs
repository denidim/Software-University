namespace MyRecipes.Services
{
    using System;
    using System.Collections.Generic;

    public class RecipeDto
    {
        public string Name { get; set; }

        public string Instructions { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public int PortionCount { get; set; }

        public string OriginalUrl { get; set; }

        public string CreatedByUserId { get; set; }

        public string CategoryName { get; set; }

        public string Image { get; set; }

        public string ImageExtension { get; set; }

        public Dictionary<string, string> IngridientsAndQuantity { get; set; }
            = new Dictionary<string, string>();
    }
}
