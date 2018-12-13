using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;
using System.Threading.Tasks;

namespace Qwill.Pages.Steps
{
    public class CustomerModel : PageModel
    {
        private readonly IWillVmService _willVmService;
        private readonly ICustomerVmService _customerVmService;
        private readonly IMaritalStatusVmService _maritalStatusService;
        private readonly IAppLogger<CustomerModel> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly string _errorNotFound;
        private readonly string _errorDefaultMessage;

        public CustomerModel(IWillVmService willVmService, ICustomerVmService customerVmService,
                             IMaritalStatusVmService maritalStatusService,
                             IAppLogger<CustomerModel> appLogger, SignInManager<ApplicationUser> signInManager,
                             UserManager<ApplicationUser> userManager)
        {
            _willVmService = willVmService;
            _customerVmService = customerVmService;
            _maritalStatusService = maritalStatusService;
            _logger = appLogger;
            _signInManager = signInManager;
            _userManager = userManager;

            _errorNotFound = "Your will could not be found.";
            _errorDefaultMessage = "It appears something went wrong. Please try again later. Should you still have the same issue, please get in touch with support.";
        }

        [BindProperty]
        public MaritalStatusVm MaritalStatusInfo { get; set; }
        [BindProperty]
        public WillVm WillInfo { get; set; } = new WillVm();
        [BindProperty]
        public CustomerVm CustomerInfo { get; set; } = new CustomerVm();

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGet(Guid id)
        {
            MaritalStatusInfo = _maritalStatusService.GetAll();

            GetWillInfo(id);

            await GetCustomerInfo();

            //var user = _userManager.FindByNameAsync(userName);

            //if (_signInManager.IsSignedIn(HttpContext.User))
            //{
            //    var x = 1;
            //}
            //else
            //{
            //    var y = 2;
            //}
        }

        private void GetWillInfo(Guid id)
        {
            try
            {
                WillInfo = _willVmService.Get(id);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogWarning("Customer GetWillInfo exception", e.Message);
                ErrorMessage = _errorNotFound;
            }
            catch (Exception e)
            {
                _logger.LogWarning("Customer GetWillInfo exception", e.Message);
                ErrorMessage = _errorDefaultMessage;
            }

            // Populate
            if (!string.IsNullOrEmpty(WillInfo.UserName))
            {
                WillInfo.UserName = HttpContext.User.Identity.Name;
            }
            else
            {
                WillInfo.UserName = "aa@aa.com";
            }
        }

        private async Task GetCustomerInfo()
        {
            try
            {
                CustomerInfo = await _customerVmService.GetByWillId(WillInfo.Id);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogWarning("Customer GetCustomerInfo exception", e.Message);
                ErrorMessage = _errorNotFound;
            }
            catch (Exception e)
            {
                _logger.LogWarning("Customer GetCustomerInfo exception", e.Message);
                ErrorMessage = _errorDefaultMessage;
            }
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                MaritalStatusInfo = _maritalStatusService.GetAll();
                return Page();
            }

            var willId = _willVmService.Post(WillInfo);
            CustomerInfo.WillId = willId ?? Guid.Empty;
            var customerId = _customerVmService.Post(CustomerInfo);

            //Error
            if (willId == null || customerId == null)
            {
                _logger.LogWarning("Customer OnPost exception", _errorDefaultMessage);

                MaritalStatusInfo = _maritalStatusService.GetAll();
                return Page();
            }

            return RedirectToPage(GetNextStep(), new { id = willId.Value });
        }

        private string GetNextStep()
        {
            var maritalStatus = _maritalStatusService.Get(CustomerInfo.MaritalStatusId);

            return (maritalStatus.Description == "Married" || maritalStatus.Description == "Civil Partnership")
                ? "/Steps/Partner"
                : "/Steps/ChildrenExisting";
        }
    }
}