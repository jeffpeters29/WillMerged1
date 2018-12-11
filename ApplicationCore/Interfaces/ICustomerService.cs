using ApplicationCore.Entities;
using System;

namespace ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        Guid? AddOrUpdate(Customer customer);
        Customer Get(Guid id);
        Customer GetByWill(Will will);
    }
}
