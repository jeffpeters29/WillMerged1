using ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Qwill.ViewModels
{
    public class PartnerVm
    {
        public Guid WillId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public bool JointAssets { get; set; }

        public DateVm DateOfBirth { get; set; }

        public AddressVm Address { get; set; }

        public Partner ToPartner()
        {
            return new Partner
            {
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth.ToDate(),
                Address = Address.ToAddress()
            };
        }
    }
}
