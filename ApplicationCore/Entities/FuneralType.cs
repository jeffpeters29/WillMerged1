using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class FuneralType
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Will> Wills { get; set; }
    }
}
