using ApplicationCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class GiftRecipient : PersonWithAddressRelationship
    {
        public string Description { get; set; }
    }
}
