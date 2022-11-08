using System.ComponentModel.DataAnnotations;

namespace MyRecipes.Web.ViewModels.Votes
{
    public class PostVotesInputModel
    {
        public int RecipeId { get; set; }

        [Range(1,5)]
        public byte Value { get; set; }
    }
}
