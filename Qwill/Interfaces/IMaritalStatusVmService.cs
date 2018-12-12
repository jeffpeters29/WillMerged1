using ApplicationCore.Entities;
using Qwill.ViewModels;
using System;

namespace Qwill.Interfaces
{
    public interface IMaritalStatusVmService
    {
        MaritalStatus Get(Guid? id);

        MaritalStatusVm GetAll();
    }
}
