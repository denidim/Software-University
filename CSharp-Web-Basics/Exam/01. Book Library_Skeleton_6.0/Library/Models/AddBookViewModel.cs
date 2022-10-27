using Library.Constants;
using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {

        [Required]
        [StringLength(BookConstants.MaxTitle, MinimumLength = BookConstants.MinTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookConstants.MaxAuthor, MinimumLength = BookConstants.MinAuthor)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookConstants.MaxDescription, MinimumLength = BookConstants.MinDescription)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
