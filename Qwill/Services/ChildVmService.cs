using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qwill.Services
{
    public class ChildVmService : IChildVmService
    {
        private readonly IChildService _childService;
        private readonly IAppLogger<ChildVmService> _logger;

        public ChildVmService(IChildService childService, IAppLogger<ChildVmService> appLogger)
        {
            _childService = childService;
            _logger = appLogger;
        }

        public ChildVm Get(Guid id)
        {
            var childVm = new ChildVm();

            if (id.IsGuid())
            {
                var child = _childService.Get(id);

                if (child == null)
                    throw new ArgumentNullException(nameof(id));

                //childVm.ChildId = child.Id;
                childVm.FirstName = child.FirstName;
                childVm.DateOfBirth = child.DateOfBirth;
            }

            return childVm;
        }

        public IEnumerable<Child> GetChildrenByWill(Guid willId)
        {
            throw new NotImplementedException();
        }

        public Guid? Post(ChildVm childVm)
        {
            try
            {
                var child = new Child()
                {
                    Id = childVm.ChildId.Value,
                    FirstName = childVm.FirstName,
                    UpdatedUtc = DateTime.UtcNow
                };

                return _childService.AddOrUpdate(child);
            }
            catch (Exception e)
            {
                _logger.LogWarning("ChildVmService Post exception", e.Message);
                return null;
            }
        }
    }
}
