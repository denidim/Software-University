using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.ValidationAttributes;

namespace WebShopDemo.Core.Models.Recipes
{
    public class AddRecipeInputMopdel
    {
        [MinLength(5, ErrorMessage = "Name must be  atleast 5 character")]
        [Required]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Name should start with capital letter.")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "slect recipe type")]
        public RecipeType RecipeType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "First time the recipe has been cooked")]
        public DateTime FirstCooked { get; set; }

        [Range(1900, int.MaxValue)]
        [CurrentYearRange(1990)]
        public int Year { get; set; }

        public RecipeTimeInputModel Time { get; set; }

        public string[] Ingredients { get; set; }

        public IFormFile? Image { get; set; }
    }
}
