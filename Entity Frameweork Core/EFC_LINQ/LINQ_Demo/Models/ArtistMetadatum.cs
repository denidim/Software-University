using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_Demo.Models
{
    [Index(nameof(ArtistId), Name = "IX_ArtistMetadata_ArtistId")]
    [Index(nameof(IsDeleted), Name = "IX_ArtistMetadata_IsDeleted")]
    [Index(nameof(SourceId), Name = "IX_ArtistMetadata_SourceId")]
    public partial class ArtistMetadatum
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int ArtistId { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("ArtistMetadata")]
        public virtual Artist Artist { get; set; }
        [ForeignKey(nameof(SourceId))]
        [InverseProperty("ArtistMetadata")]
        public virtual Source Source { get; set; }
    }
}
