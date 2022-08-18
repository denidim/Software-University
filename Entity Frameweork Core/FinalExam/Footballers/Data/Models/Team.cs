using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
/*Id – integer, Primary Key 

Name – text with length [3, 40]. May contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required) 

Nationality – text with length [2, 40] (required) 

Trophies – integer (required) 

TeamsFootballers – collection of type TeamFootballer */