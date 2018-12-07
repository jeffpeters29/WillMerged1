using ApplicationCore.Entities.Common;
using System;

namespace ApplicationCore.Entities
{
    public class Child : Person
    {
        public DateTime DateOfBirth { get; set; }

        //-------------

        public bool IsAddressSame{ get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

        public Guid? LegalGuardianId { get; set; }
        public LegalGuardian LegalGuardian { get; set; }

    }
}
