using System;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;

namespace ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IAppLogger<CustomerService> _logger;

        public CustomerService(IRepository<Customer> repository, IAppLogger<CustomerService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Guid? AddOrUpdate(Customer customer)
        {
            try
            {
                if (customer.Id.IsGuidEmpty())
                {
                    //Add
                    var resultcustomer = _repository.Add(customer);
                    return resultcustomer?.Id;
                }
                else
                {
                    //Update
                    _repository.Update(customer);
                    return customer.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"CustomerService : Error saving {customer.Id}", ex.Message);
                return null;
            }
        }

        public Customer Get(Guid id)
        {
            var spec = new CustomerSpecification(id);
            return _repository.GetSingleBySpec(spec);
        }

        public Customer GetByWill(Will will)
        {
            var spec = new CustomerSpecification(will);
            return _repository.GetSingleBySpec(spec);
        }
    }
}
