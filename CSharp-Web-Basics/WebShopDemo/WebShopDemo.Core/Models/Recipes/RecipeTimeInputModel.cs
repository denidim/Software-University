using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Core.Models.Recipes
{
    public class RecipeTimeInputModel : IValidatableObject
    {
        [Range(1, 24 * 60)]
        public int PreparationTime { get; set; }


        [Range(1, 2 * 24 * 60)]
        public int CookingTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(PreparationTime > CookingTime)
            {
                yield return new ValidationResult("Preparation time cannot be more than cooking time");
            }

            if(PreparationTime + CookingTime > 2.5 * 24 * 60)
            {
                yield return new ValidationResult("Preparation time cannot be more than cooking time");
            }
        }
    }
}
