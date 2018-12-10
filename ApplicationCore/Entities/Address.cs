using ApplicationCore.Entities.Common;

namespace ApplicationCore.Entities
{
    public class Address : EntityBaseWithGuid
    {
        public string Postcode { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }

        public string Village { get; set; }

        public string City { get; set; }

        //-------------

        public Customer Customer { get; set; }

        public Partner Partner { get; set; }

        public Child Child { get; set; }

        public LegalGuardian LegalGuardian { get; set; }

        public Trustee Trustee { get; set; }

        public Executor Executor { get; set; }

        public GiftRecipient GiftRecipient { get; set; }

        public CashRecipient CashRecipient { get; set; }

        public ResidueRecipient ResidueRecipient { get; set; }

        public Witness Witness { get; set; }
    }
}
