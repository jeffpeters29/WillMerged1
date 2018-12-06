﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Partner : Person
    {
        public DateTime DateOfBirth { get; set; }

        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
