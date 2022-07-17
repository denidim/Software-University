using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace codeFirstDemo.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int NewsId { get; set; }

        public virtual News news { get; set; }

        [MaxLength(50)]
        public string Author { get; set; }

        public string Content { get; set; }
    }
}
