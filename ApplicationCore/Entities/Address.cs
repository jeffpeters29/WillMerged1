using ApplicationCore.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Address : EntityBaseWithGuid
    {
        public string Postcode { get; set; }

        public Will Will { get; set; }
    }
}
