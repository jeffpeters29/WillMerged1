using ApplicationCore.Entities;
using ApplicationCore.Entities.Common;
using ApplicationCore.Enums;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;
using System.Collections.Generic;

namespace Qwill.Services
{
    public class WillVmService : IWillVmService
    {
        private readonly IWillsService _willService;
        private readonly IAppLogger<WillVmService> _logger;

        public WillVmService(IWillsService willService, IAppLogger<WillVmService> appLogger)
        {
            _willService = willService;
            _logger = appLogger;
        }

        public WillVm Get(Guid id)
        {
            var willVm = new WillVm()
            {
                Children = new List<Child>()
            };

            if (id.IsGuid())
            {
                var will = _willService.GetWill(id);

                if (will == null)
                    throw new ArgumentNullException(nameof(id));

                willVm.Id = will.Id;
                willVm.WillStatus = will.WillStatus;
                willVm.Customer.FirstName = will.Customer.FirstName;
                willVm.Customer.DateOfBirth = will.Customer.DateOfBirth;
            }

            return willVm;
        }

        public Guid? Post(WillVm willVm)
        {
            try
            {
                var will = new Will()
                {
                    WillStatus = willVm.WillStatus,
                    Customer = willVm.Customer,
                    Children = willVm.Children,
                    UpdatedUtc = DateTime.UtcNow
                };

                return _willService.AddOrUpdate(will);
            }
            catch (Exception e)
            {
                _logger.LogWarning("WillVmService Post exception", e.Message);

                return null;
            }
        }

        public Guid? Create(WillVm willVm)
        {
            try
            {
                //var customer = new Customer() { FullName = willVm.FullName };

                var will = new Will()
                {
                    WillStatus = willVm.WillStatus,
                    Customer = willVm.Customer,
                    Children = willVm.Children,
                    UpdatedUtc = DateTime.UtcNow
                };

                return _willService.AddOrUpdate(will);
            }
            catch (Exception e)
            {
                _logger.LogWarning("WillVmService Post exception", e.Message);

                return null;
            }
        }
    }
}
