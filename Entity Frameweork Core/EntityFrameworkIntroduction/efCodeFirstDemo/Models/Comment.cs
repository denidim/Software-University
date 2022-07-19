using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace efCodeFirstDemo.Models
{
    [Index(nameof(QuestionID), Name = "Ix_QuestionId123")]
    internal class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public int QuestionID{ get; set; }

        public Question Question { get; set; }
    }
}
