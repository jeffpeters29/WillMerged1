using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Common
{
    public class PersonWithAddress : Person
    {
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
