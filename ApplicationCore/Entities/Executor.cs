using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Executor : Person
    {
        public string Email { get; set; }

        public bool IsAwareFinances { get; set; }

        //----------

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

        public Will Will { get; set; }
    }
}
