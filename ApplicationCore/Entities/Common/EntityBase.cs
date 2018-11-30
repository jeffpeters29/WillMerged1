using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities.Common
{
    public class EntityBase
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdatedUtc { get; set; } = DateTime.UtcNow;
    }
}
