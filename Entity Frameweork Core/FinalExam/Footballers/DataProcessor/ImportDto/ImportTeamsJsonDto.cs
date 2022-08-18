using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamsJsonDto
    {
        [Required]
        [RegularExpression(@"[A-Za-z0-9||\s||.||\-]{3,40}")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
/*
 Id – integer, Primary Key 

Name – text with length [3, 40]. May contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required) 

Nationality – text with length [2, 40] (required) 

Trophies – integer (required) 

TeamsFootballers – collection of type TeamFootballer */