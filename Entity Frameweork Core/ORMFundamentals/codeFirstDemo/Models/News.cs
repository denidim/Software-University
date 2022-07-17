using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace codeFirstDemo.Models
{
    public class News
    {
        public News()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
