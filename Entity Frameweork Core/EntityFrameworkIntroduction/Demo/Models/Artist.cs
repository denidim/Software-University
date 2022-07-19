using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Demo.models
{
    [Index(nameof(IsDeleted), Name = "IX_Artists_IsDeleted")]
    public partial class Artist
    {
        public Artist()
        {
            ArtistMetadata = new HashSet<ArtistMetadatum>();
            SongArtists = new HashSet<SongArtist>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal? MoneyEarned { get; set; }

        [InverseProperty(nameof(ArtistMetadatum.Artist))]
        public virtual ICollection<ArtistMetadatum> ArtistMetadata { get; set; }
        [InverseProperty(nameof(SongArtist.Artist))]
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
