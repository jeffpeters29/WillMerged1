using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.ViewModels;
using System.Threading.Tasks;

namespace Qwill.Pages.Steps
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterModel(SignInManager<ApplicationUser> signInManager,
                             UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public RegisterVm UserDetails { get; set; }

        public async Task<IActionResult> OnPostCreateAccount()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = UserDetails.Email, Email = UserDetails.Email };
                var result = await _userManager.CreateAsync(user, UserDetails.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("/Steps/Customer");
                }
                AddErrors(result);
            }
            return Page();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

    }
}