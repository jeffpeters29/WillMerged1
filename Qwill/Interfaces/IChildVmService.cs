using ApplicationCore.Entities;
using Qwill.ViewModels;
using System;
using System.Collections.Generic;

namespace Qwill.Interfaces
{
    public interface IChildVmService
    {
        ChildVm Get(Guid id);

        IEnumerable<Child> GetChildrenByWill(Guid willId);

        Guid? Post(ChildVm childVm);
    }
}
