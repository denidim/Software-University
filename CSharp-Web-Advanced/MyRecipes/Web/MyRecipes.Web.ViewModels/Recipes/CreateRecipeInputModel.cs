namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using MyRecipes.Data.Models;

    public class CreateRecipeInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Instructions { get; set; }

        [Range(0, 60 * 24)]
        [Display(Name = "Preparation time (in minutes)")]
        public double PreparationTime { get; set; }

        [Range(0, 60 * 24)]
        [Display(Name ="Cooking time (in minutes)")]
        public double CookingTime { get; set; }

        [Range(1, 100)]
        public int PortionCount { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }

        [Display(Name = "Choose Category")]
        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
            = new List<KeyValuePair<string, string>>();
    }
}
