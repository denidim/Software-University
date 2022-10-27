using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Library.Constants;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BookConstants.MaxTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookConstants.MaxAuthor)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookConstants.MaxDescription)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl  { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new HashSet<ApplicationUserBook>();

    }
}
