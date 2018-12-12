using ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IMaritalStatusService
    {
        MaritalStatus Get(Guid? id);
        IEnumerable<MaritalStatus> GetAll();
    }
}
