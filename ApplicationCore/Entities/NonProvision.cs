using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class NonProvision : Person
    {
        public string ReasonWhy { get; set; }

        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

        public Will Will { get; set; }
    }
}
