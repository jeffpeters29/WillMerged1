using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Qwill.ViewModels
{
    public class AddressVm
    {
        [Required]
        [MinLength(5, ErrorMessage = "Minimum 5 characters required")]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Display(Name = "Address Line 1")]
        [Required]
        public string Number { get; set; }

        [Display(Name = "Address Line 2")]
        public string Street { get; set; }

        [Display(Name = "Address Line 3")]
        public string Village { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        public string Token { get; set; }
        public bool IsLive { get; set; } = false;

        public Address ToAddress()
        {
            return new Address
            {
                Postcode = Postcode,
                Number = Number,
                Street = Street,
                Village = Village,
                City = City
            };
        }
    }
}
