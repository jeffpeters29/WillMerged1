using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;
using System.Threading.Tasks;

namespace Qwill.Services
{
    public class CustomerVmService : ICustomerVmService
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressVmService _addressVmService;
        private readonly IAppLogger<CustomerVmService> _logger;

        public CustomerVmService(ICustomerService customerService, IAppLogger<CustomerVmService> appLogger, IAddressVmService addressVmService)
        {
            _customerService = customerService;
            _logger = appLogger;
            _addressVmService = addressVmService;
        }

        public async Task<CustomerVm> Get(Guid id)
        {
            var customerVm = new CustomerVm() { Address = await _addressVmService.Get() };

            if (id.IsGuid())
            {
                var customer = _customerService.Get(id);

                if (customer == null)
                    throw new ArgumentNullException(nameof(id));

                customerVm = Populate(customer, customerVm.Address);
            }

            return customerVm;
        }

        public async Task<CustomerVm> GetByWillId(Guid willId)
        {
            var customerVm = new CustomerVm() { Address = await _addressVmService.Get() };

            if (willId.IsGuid())
            {
                var customer = _customerService.GetByWill(new Will() { Id = willId });

                if (customer == null)
                    throw new ArgumentNullException(nameof(willId));

                customerVm = Populate(customer, customerVm.Address);
            }

            return customerVm;
        }

        private CustomerVm Populate(Customer customer, AddressVm addressVm)
        {
            var customerVm = new CustomerVm
            {
                WillId = customer.Will.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = PopulateAddressVm(customer, addressVm),
                DateOfBirth = new DateVm
                {
                    DateOfBirth = customer.DateOfBirth.Date,
                    Day = customer.DateOfBirth.Day,
                    Month = customer.DateOfBirth.Month,
                    Year = customer.DateOfBirth.Year,
                }
            };

            return customerVm;
        }

        private AddressVm PopulateAddressVm(Customer customer, AddressVm addressVm)
        {
            addressVm.Number = customer.Address.Number;
            addressVm.Street = customer.Address.Street;
            addressVm.Village = customer.Address.Village;
            addressVm.City = customer.Address.City;
            addressVm.Postcode = customer.Address.Postcode;
            return addressVm;
        }

        public Guid? Post(CustomerVm customerVm)
        {
            try
            {
                var customer = new Customer()
                {
                    FirstName = customerVm.FirstName,
                    LastName = customerVm.LastName,
                    DateOfBirth = new DateTime(customerVm.DateOfBirth.Year, customerVm.DateOfBirth.Month, customerVm.DateOfBirth.Day),
                    Address = customerVm.Address.ToAddress(),
                    UpdatedUtc = DateTime.UtcNow
                };

                return _customerService.AddOrUpdate(customer);
            }
            catch (Exception e)
            {
                _logger.LogWarning("CustomerVmService Post exception", e.Message);
                return null;
            }
        }
    }
}
