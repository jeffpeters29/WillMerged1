using ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Qwill.ViewModels
{
    public class CustomerVm
    {
        public Guid WillId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Telephone { get; set; }

        public DateVm DateOfBirth { get; set; }

        public AddressVm Address { get; set; }

        public Guid? MaritalStatusId { get; set; }

        public Customer ToCustomer()
        {
            return new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth.ToDate(),
                Address = Address.ToAddress()
            };
        }
    }
}
