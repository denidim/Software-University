using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Demo.models
{
    [Index(nameof(ArtistId), Name = "IX_SongArtists_ArtistId")]
    [Index(nameof(IsDeleted), Name = "IX_SongArtists_IsDeleted")]
    [Index(nameof(SongId), Name = "IX_SongArtists_SongId")]
    public partial class SongArtist
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public int? Order { get; set; }

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("SongArtists")]
        public virtual Artist Artist { get; set; }
        [ForeignKey(nameof(SongId))]
        [InverseProperty("SongArtists")]
        public virtual Song Song { get; set; }
    }
}
