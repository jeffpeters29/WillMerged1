using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Qwill.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostNewWill()
        {
            //return RedirectToPage("/Steps/Prerequisites/WhereLive");

            //return RedirectToPage("/Steps/Register");

            return RedirectToPage("/Steps/Customer");
        }
    }
}
