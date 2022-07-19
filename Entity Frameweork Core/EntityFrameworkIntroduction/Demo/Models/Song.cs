using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Demo.models
{
    [Index(nameof(IsDeleted), Name = "IX_Songs_IsDeleted")]
    [Index(nameof(SourceId), Name = "IX_Songs_SourceId")]
    public partial class Song
    {
        public Song()
        {
            SongArtists = new HashSet<SongArtist>();
            SongMetadata = new HashSet<SongMetadatum>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        [Required]
        public string Name { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }
        public string SearchTerms { get; set; }

        [ForeignKey(nameof(SourceId))]
        [InverseProperty("Songs")]
        public virtual Source Source { get; set; }
        [InverseProperty(nameof(SongArtist.Song))]
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        [InverseProperty(nameof(SongMetadatum.Song))]
        public virtual ICollection<SongMetadatum> SongMetadata { get; set; }
    }
}
