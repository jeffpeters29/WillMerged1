using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.ViewModels;
using System;

namespace Qwill.Pages
{
    public class EditModel : PageModel
    {
        private readonly IWillsService _willService;
        private readonly IAppLogger<EditModel> _logger;

        private readonly string _errorNotFound;

        public EditModel(IWillsService willService, IAppLogger<EditModel> appLogger)
        {
            _willService = willService;
            _logger = appLogger;

            _errorNotFound = "Your will could not be found.";
        }

        [BindProperty]
        public WillVm WillInfo { get; set; } = new WillVm();

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet(Guid id)
        {
            if (id == null)
            {
                ErrorMessage = _errorNotFound;
                _logger.LogWarning($"Edit - Will could not be found : {id}");
                RedirectToPage("Edit");
            }

            var will = _willService.GetWill(id);
            WillInfo.Id = will.Id;
            WillInfo.FullName = will.FullName;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var will = new Will() { FullName = WillInfo.FullName, UpdatedUtc=DateTime.UtcNow };

            _willService.AddOrUpdate(will);

            return RedirectToPage("/Edit2/" + WillInfo.Id);
        }
    }
}