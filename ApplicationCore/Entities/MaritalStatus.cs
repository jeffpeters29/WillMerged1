using System;

namespace ApplicationCore.Entities
{
    public class MaritalStatus
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }
    }
}
