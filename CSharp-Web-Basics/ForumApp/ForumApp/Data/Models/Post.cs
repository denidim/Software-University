using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Constants.DataConstants.Post;

namespace ForumApp.Data.Models
{
    [Comment("Published posts")]
    public class Post
    {
        [Key]
        [Comment("Post Identidier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Post title")]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Content")]
        [MaxLength(ContextMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("Marks record as deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
