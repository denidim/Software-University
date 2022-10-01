
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [Range(00.5,1000)]
        public decimal Price { get; set; }

        [StringLength(36)]
        public string CardId { get; set; }

        [ForeignKey(nameof(CardId))]
        public Cart Cart { get; set; }
    }
}
/*
 Has an Id – a string, Primary Key 

Has a Name – a string with min length 4 and max length 20 (required) 

Has Price – a decimal (in range 0.05 – 1000) 

Has a Cart – a Cart object */