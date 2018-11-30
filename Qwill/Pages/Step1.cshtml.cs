using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.ViewModels;
using System;

namespace Qwill.Pages
{
    public class Step1Model : PageModel
    {
        private readonly IWillsService _willService;
        private readonly IAppLogger<EditModel> _appLogger;

        private readonly string _errorNotFound;

        public Step1Model(IWillsService willService, IAppLogger<EditModel> appLogger)
        {
            _willService = willService;
            _appLogger = appLogger;

            _errorNotFound = "Your will could not be found.";
        }

        [BindProperty]
        public WillVm WillInfo { get; set; } = new WillVm();

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet(Guid id)
        {
            if (id.IsGuid())
            {
                // Edit
                var will = _willService.GetWill(id);

                if (will != null)
                {
                    WillInfo.Id = will.Id;
                    WillInfo.FullName = will.FullName;
                }
                else
                {
                    ErrorMessage = _errorNotFound;
                    _appLogger.LogWarning($"Edit - Will could not be found : {id}");
                }
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var will = new Will()
            {
                FullName = WillInfo.FullName,
                Email = WillInfo.Email,
                UpdatedUtc = DateTime.UtcNow
            };

            _willService.AddOrUpdate(will);

            return RedirectToPage("/Step2/" + WillInfo.Id);
        }
    }
}