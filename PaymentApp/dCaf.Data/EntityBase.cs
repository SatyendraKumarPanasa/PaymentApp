using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dCaf.Data
{
    public abstract class EntityBase<T> : IIdentifiable<T> where T : IEquatable<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; } = default!;

        [Timestamp]
        public byte[]? RecordVersion { get; set; }

        [Required]
        [MaxLength(320)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(320)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
