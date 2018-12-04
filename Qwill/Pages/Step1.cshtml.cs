using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;

namespace Qwill.Pages
{
    public class Step1Model : PageModel
    {
        private readonly IWillVmService _willVmService;
        private readonly IAppLogger<EditModel> _logger;

        private readonly string _errorNotFound;
        private readonly string _errorDefaultMessage;

        public Step1Model(IWillVmService willVmService, IAppLogger<EditModel> appLogger)
        {
            _willVmService = willVmService;
            _logger = appLogger;

            _errorNotFound = "Your will could not be found.";
            _errorDefaultMessage = "It appears something went wrong. Please try again later. Should you still have the same issue, please get in touch with support.";
        }

        [BindProperty]
        public WillVm WillInfo { get; set; } = new WillVm();

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet(Guid id)
        {
            try
            {
                WillInfo = _willVmService.Get(id);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogWarning("Step1 OnGet exception", e.Message);
                ErrorMessage = _errorNotFound;
            }
            catch (Exception e)
            {
                _logger.LogWarning("Step1 OnGet exception", e.Message);
                ErrorMessage = _errorDefaultMessage;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var willId = _willVmService.Post(WillInfo);

            //Success
            if (willId != null) return RedirectToPage("/Step2", new { id = willId.Value });

            //Error
            _logger.LogWarning("Step1 OnPost exception", _errorDefaultMessage);
            return Page();
        }
    }
}