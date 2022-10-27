using Library.Constants;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstants.MaxCategoryName)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
