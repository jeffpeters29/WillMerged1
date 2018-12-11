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
            //{
            //Children = new List<Child>()
            //};

            if (id.IsGuid())
            {
                var will = _willService.Get(id);

                if (will == null)
                    throw new ArgumentNullException(nameof(id));

                willVm.Id = will.Id;
                willVm.WillStatus = will.WillStatus;
                willVm.UserName = will.UserName;
                //willVm.Customer.FirstName = will.Customer.FirstName;
                //willVm.Customer.DateOfBirth.Day = will.Customer.DateOfBirth.Day;
                //willVm.Customer.DateOfBirth.Month = will.Customer.DateOfBirth.Month;
                //willVm.Customer.DateOfBirth.Year = will.Customer.DateOfBirth.Year;
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
                    //Customer = willVm.Customer.ToCustomer(),
                    //Children = willVm.Children,
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

        //public Guid? Create(WillVm willVm)
        //{
        //    try
        //    {
        //        //var customer = new Customer() { FullName = willVm.FullName };

        //        var will = new Will()
        //        {
        //            WillStatus = willVm.WillStatus,
        //            Customer = willVm.Customer.ToCustomer(),
        //            Children = willVm.Children,
        //            UpdatedUtc = DateTime.UtcNow
        //        };

        //        return _willService.AddOrUpdate(will);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogWarning("WillVmService Post exception", e.Message);

        //        return null;
        //    }
        //}
    }
}
