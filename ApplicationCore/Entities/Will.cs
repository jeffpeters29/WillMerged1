using ApplicationCore.Entities.Common;
using ApplicationCore.Enums;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Will : EntityBaseWithGuid
    {
        public string UserId { get; set; }

        public WillStatus WillStatus { get; set; }

        //-------------

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid? PartnerId { get; set; }
        public Partner Partner { get; set; }

        public ICollection<Child> Children { get; set; }

        public ICollection<Executor> Executors { get; set; }

        public ICollection<Trustee> Trustees { get; set; }

        public ICollection<CashRecipient> CashRecipients { get; set; }

        public ICollection<GiftRecipient> GiftRecipients { get; set; }

        public ICollection<ResidueRecipient> ResidueRecipients { get; set; }

        public ICollection<NonProvision> NonProvisions { get; set; }

        public ICollection<LegalGuardian> LegalGuardians { get; set; }

        public ICollection<Witness> Witnesses { get; set; } 

        //-------------

        public Guid FuneralTypeId { get; set; }
        public FuneralType FuneralType { get; set; }

        public string FuneralWishes { get; set; }
    }
}
