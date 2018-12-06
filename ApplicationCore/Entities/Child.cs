﻿using System;

namespace ApplicationCore.Entities
{
    public class Child : Person
    {
        public DateTime DateOfBirth { get; set; }

        //-------------

        public bool IsAddressSame{ get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }


        public Guid? LegalGuardianId { get; set; }
        public LegalGuardian LegalGuardian { get; set; }


        public Will Will { get; set; }
    }
}
