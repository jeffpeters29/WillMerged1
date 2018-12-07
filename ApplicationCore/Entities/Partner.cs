using ApplicationCore.Entities.Common;
using System;

namespace ApplicationCore.Entities
{
    public class Partner : PersonWithAddress
    {
        public DateTime DateOfBirth { get; set; }
    }
}
