using ApplicationCore.Entities.Common;
using System;

namespace ApplicationCore.Entities
{
    public class ResidueRecipient : PersonWithAddressRelationship
    {
        public int Level { get; set; }

        public decimal Percentage { get; set; }
    }
}
