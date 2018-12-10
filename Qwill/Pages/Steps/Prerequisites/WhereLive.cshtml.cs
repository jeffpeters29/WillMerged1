using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;

namespace Qwill.Pages.Steps.Prerequisites
{
    public class WhereLiveModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostAcceptable()
        {
            return RedirectToPage("/Steps/Prerequisites/Following");
        }

        public IActionResult OnPostElsewhere()
        {
            return RedirectToPage("/Steps/Prerequisites/NotPossible");
        }
    }
}