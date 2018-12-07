using System;

namespace ApplicationCore.Entities.Common
{
    public class PersonWithAddressRelationship : PersonWithAddress
    {
        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }
    }
}
