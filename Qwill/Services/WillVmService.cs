using ApplicationCore.Entities;
using ApplicationCore.Entities.Common;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;

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
            var willVm = new WillVm();

            if (id.IsGuid())
            {
                // Edit
                var will = _willService.GetWill(id);

                if (will == null)
                    throw new ArgumentNullException(nameof(id));

                willVm.Id = will.Id;
                willVm.FullName = will.FullName;
                willVm.Email = will.Email;
            }

            return willVm;
        }


        public Result Post(WillVm willVm)
        {
            try
            {
                var will = new Will()
                {
                    FullName = willVm.FullName,
                    Email = willVm.Email,
                    UpdatedUtc = DateTime.UtcNow
                };

                return _willService.AddOrUpdate(will);
            }
            catch (Exception e)
            {
                _logger.LogWarning("WillVmService Post exception", e.Message);
                return new Result
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
    }
}
