using System.ComponentModel.DataAnnotations;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.ValidationAttributes;

namespace WebShopDemo.Core.Models.Recipes
{
    public class AddRecipeInputMopdel
    {
        [MinLength(5)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public RecipeType RecipeType { get; set; }

        public DateTime FirstCooked { get; set; }

        [Range(1900, int.MaxValue)]
        [CurrentYearRange(1990)]
        public int Year { get; set; }

        public RecipeTimeInputModel Time { get; set; }

        public string[] Ingredients { get; set; }
    }
}
