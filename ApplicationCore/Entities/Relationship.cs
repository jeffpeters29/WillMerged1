using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Relationship 
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        //-----------

        public Child Child { get; set; }

        public LegalGuardian LegalGuardian { get; set; }

        public Trustee Trustee { get; set; }

        public Executor Executor { get; set; }

        public GiftRecipient GiftRecipient { get; set; }

        public CashRecipient CashRecipient { get; set; }

        public ResidueRecipient ResidueRecipient { get; set; }

        public NonProvision NonProvision { get; set; }
    }
}
