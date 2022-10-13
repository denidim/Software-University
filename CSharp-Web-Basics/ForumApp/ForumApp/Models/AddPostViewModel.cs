using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ForumApp.Models
{
    public class AddPostViewModel
    {
        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "полето {0} е задължително")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "полето {0} трябва да е между {2} и {1} символа")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = "полето {0} е задължително")]
        [StringLength(1500, MinimumLength = 30, ErrorMessage = "полето {0} трябва да е между {2} и {1} символа")]
        public string Content { get; set; }
    }
}
