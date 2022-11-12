namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using MyRecipes.Data.Models;

    public class CreateRecipeInputModel : BaseRecipeInputModel
    {
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }
    }
}
