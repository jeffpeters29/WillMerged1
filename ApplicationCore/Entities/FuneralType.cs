using ApplicationCore.Entities.Common;
using System;

namespace ApplicationCore.Entities
{
    public class FuneralType 
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Will Will { get; set; }
    }
}
