using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }


        public string[] Tags { get; set; }
    }
}
/*
 Id – integer, Primary Key 

Name – text (required) 

Price – decimal (non-negative, minimum value: 0) (required) 

ReleaseDate – Date (required) 

DeveloperId – integer, foreign key (required) 

Developer – the game’s developer (required) 

GenreId – integer, foreign key (required) 

Genre – the game’s genre (required) 

Purchases - collection of type Purchase 

GameTags - collection of type GameTag. Each game must have at least one tag. */