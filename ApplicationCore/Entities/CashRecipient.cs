using ApplicationCore.Entities.Common;
using System;

namespace ApplicationCore.Entities
{
    public class CashRecipient : PersonWithAddressRelationship
    {
        public decimal Amount { get; set; }
    }
}
