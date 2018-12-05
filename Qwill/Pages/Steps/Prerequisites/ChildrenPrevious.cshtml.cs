using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Qwill.Pages.Steps.Prerequisites
{
    public class ChildrenPreviousModel : PageModel
    {
        public IActionResult OnGet()
        {
            var referer = Request.Headers["Referer"].ToString();

            if (!IsValidReferer(referer))
                return RedirectToPage("/Steps/NotPossible");

            return Page();
        }

        public bool IsValidReferer(string referer)
        {
            return referer.Contains("/Steps/Prerequisites/Following");
        }

        public IActionResult OnPostYes()
        {
            return RedirectToPage("/Steps/NotPossible");
        }

        public IActionResult OnPostNo()
        {
            return RedirectToPage("/Steps/ChildrenExisting");
        }

        public IActionResult OnPostGoBack()
        {
            return RedirectToPage("/Steps/Prerequisites/Following");
        }
    }
}