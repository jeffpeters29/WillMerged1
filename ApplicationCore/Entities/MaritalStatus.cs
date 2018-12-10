using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class MaritalStatus
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
