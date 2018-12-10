using ApplicationCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class LegalGuardian : PersonWithAddress
    {
        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

        public Child Child { get; set; }
    }
}
