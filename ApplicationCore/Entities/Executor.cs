using ApplicationCore.Entities.Common;
using System;

namespace ApplicationCore.Entities
{
    public class Executor : PersonWithAddressRelationship
    {
        public string Email { get; set; }

        public bool IsAwareFinances { get; set; }
    }
}
