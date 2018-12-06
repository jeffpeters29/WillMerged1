using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class LegalGuardian : Person
    {
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

        public Child Child { get; set; }
    }
}
