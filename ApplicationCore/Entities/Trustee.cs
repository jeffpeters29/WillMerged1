using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Trustee : Person
    {
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
