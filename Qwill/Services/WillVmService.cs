using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;

namespace Qwill.Services
{
    public class WillVmService : IWillVmService
    {
        private readonly IWillService _willService;
        private readonly IAppLogger<WillVmService> _logger;

        public WillVmService(IWillService willService, IAppLogger<WillVmService> appLogger)
        {
            _willService = willService;
            _logger = appLogger;
        }

        public WillVm Get(Guid id)
        {
            var willVm = new WillVm();

            if (id.IsGuid())
            {
                var will = _willService.Get(id);

                if (will == null)
                    throw new ArgumentNullException(nameof(id));

                willVm.Id = will.Id;
                willVm.WillStatus = will.WillStatus;
                willVm.UserName = will.UserName;
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
                    UserName = willVm.UserName,
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
