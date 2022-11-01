namespace MyRecipes.Data.Models
{
    using System.Collections.Generic;

    using MyRecipes.Data.Common.Models;

    public class Ingredient : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> Recipes { get; set; } = new HashSet<RecipeIngredient>();
    }
}
