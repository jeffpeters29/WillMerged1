using ApplicationCore.Entities.Common;
using ApplicationCore.Enums;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Will : EntityBaseWithGuid
    {
        public WillStatus WillStatus { get; set; }

        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
