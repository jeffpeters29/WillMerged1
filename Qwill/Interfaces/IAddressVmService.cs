using Qwill.ViewModels;
using System.Threading.Tasks;

namespace Qwill.Interfaces
{
    public interface IAddressVmService
    {
        Task<AddressVm> Get();
    }
}
