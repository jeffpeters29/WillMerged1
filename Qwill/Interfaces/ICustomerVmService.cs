using Qwill.ViewModels;
using System;
using System.Threading.Tasks;

namespace Qwill.Interfaces
{
    public interface ICustomerVmService
    {
        Task<CustomerVm> Get(Guid id);
        Task<CustomerVm> GetByWillId(Guid id);
        Guid? Post(CustomerVm customerVm);
    }
}
