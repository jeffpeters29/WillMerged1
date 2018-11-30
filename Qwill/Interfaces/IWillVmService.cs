using ApplicationCore.Entities.Common;
using Qwill.ViewModels;
using System;
using System.Threading.Tasks;

namespace Qwill.Interfaces
{
    public interface IWillVmService
    {
        WillVm Get(Guid id);
        Result Post(WillVm willVm);
    }
}
