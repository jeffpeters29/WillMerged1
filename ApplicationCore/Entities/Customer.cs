using ApplicationCore.Entities.Common;
using System;

namespace ApplicationCore.Entities
{
    public class Customer : PersonWithAddress
    {
        public DateTime DateOfBirth { get; set; }

        public string Telephone { get; set; }

        public Guid MaritalStatusId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }
}
