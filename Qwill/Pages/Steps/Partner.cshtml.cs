using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.Interfaces;
using Qwill.ViewModels;

namespace Qwill.Pages.Steps
{
    public class PartnerModel : PageModel
    {
        private readonly IWillVmService _willVmService;
        private readonly IAppLogger<PartnerModel> _logger;

        private readonly string _errorNotFound;
        private readonly string _errorDefaultMessage;

        public PartnerModel(IWillVmService willVmService, IAppLogger<PartnerModel> appLogger)
        {
            _willVmService = willVmService;
            _logger = appLogger;

            _errorNotFound = "Your will could not be found.";
            _errorDefaultMessage = "It appears something went wrong. Please try again later. Should you still have the same issue, please get in touch with support.";
        }

        [BindProperty]
        public WillVm WillInfo { get; set; } = new WillVm();
        [BindProperty]
        public PartnerVm PartnerInfo { get; set; } = new PartnerVm();

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet(Guid id)
        {
            GetWillInfo(id);

            //await GetCustomerInfo();
        }

        private void GetWillInfo(Guid id)
        {
            try
            {
                WillInfo = _willVmService.Get(id);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogWarning("Partner GetWillInfo exception", e.Message);
                ErrorMessage = _errorNotFound;
            }
            catch (Exception e)
            {
                _logger.LogWarning("Partner GetWillInfo exception", e.Message);
                ErrorMessage = _errorDefaultMessage;
            }
        }

    }
}