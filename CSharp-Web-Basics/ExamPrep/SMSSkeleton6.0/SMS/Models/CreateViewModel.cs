using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(20,MinimumLength = 4, ErrorMessage = "{0} must be between {2} and {1} characters!")]
        public string Name { get; set; }

        public string Price { get; set; }

    }
}
