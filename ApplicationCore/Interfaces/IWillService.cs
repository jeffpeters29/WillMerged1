using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IWillService
    {
        Guid? AddOrUpdate(Will will);
        Will Get(Guid id);
        IEnumerable<Will> GetWills();
    }
}
