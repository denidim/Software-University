using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Footballers = new HashSet<Footballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Nationality { get; set; }

        public ICollection<Footballer> Footballers{ get; set; }
    }
}
/*Id – integer, Primary Key 

Name – text with length [2, 40] (required) 

Nationality – text (required) 

Footballers – collection of type Footballer */