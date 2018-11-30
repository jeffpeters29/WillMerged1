using ApplicationCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Will : EntityBaseWithGuid
    {
        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
