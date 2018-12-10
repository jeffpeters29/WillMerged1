using ApplicationCore.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class ResidueRecipient : PersonWithAddressRelationship
    {
        public int Level { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Percentage { get; set; }
    }
}
