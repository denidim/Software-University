using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Demo.models
{
    [Index(nameof(IsDeleted), Name = "IX_SongMetadata_IsDeleted")]
    [Index(nameof(SongId), Name = "IX_SongMetadata_SongId")]
    [Index(nameof(SourceId), Name = "IX_SongMetadata_SourceId")]
    public partial class SongMetadatum
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int SongId { get; set; }
        public short Type { get; set; }
        public string Value { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }

        [ForeignKey(nameof(SongId))]
        [InverseProperty("SongMetadata")]
        public virtual Song Song { get; set; }
        [ForeignKey(nameof(SourceId))]
        [InverseProperty("SongMetadata")]
        public virtual Source Source { get; set; }
    }
}
