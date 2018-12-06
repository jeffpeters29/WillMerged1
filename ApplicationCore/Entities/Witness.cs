using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Witness : Person
    {
        public string Occupation { get; set; }

        //-------------

        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public Will Will { get; set; }
    }
}
