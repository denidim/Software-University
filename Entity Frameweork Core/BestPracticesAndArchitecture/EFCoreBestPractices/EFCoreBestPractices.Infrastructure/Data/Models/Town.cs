using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices.Infrastructure.Data.Models
{ 
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        [Column("TownID")]
        public int TownId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [StringLength(2)]
        [Unicode(false)]
        public string Country { get; set; } = null!;

        [InverseProperty("Town")]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
