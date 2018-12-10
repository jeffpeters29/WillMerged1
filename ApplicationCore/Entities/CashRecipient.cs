using ApplicationCore.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class CashRecipient : PersonWithAddressRelationship
    {
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
    }
}
