using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class ResidueRecipient : Person
    {
        public int Level { get; set; }

        public decimal Percentage { get; set; }

        //----------

        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }
    }
}
