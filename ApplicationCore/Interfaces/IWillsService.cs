using ApplicationCore.Entities;
using ApplicationCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IWillsService
    {
        Result AddOrUpdate(Will will);
        Will GetWill(Guid id);
        IEnumerable<Will> GetWills();
    }
}
