using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.Interfaces;

namespace Qwill.Pages.Steps
{
    public class CustomerModel : PageModel
    {
        private readonly IWillVmService _willVmService;
        private readonly IAppLogger<CustomerModel> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly string _errorNotFound;
        private readonly string _errorDefaultMessage;

        public CustomerModel(IWillVmService willVmService, IAppLogger<CustomerModel> appLogger
                            ,SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _willVmService = willVmService;
            _logger = appLogger;
            _signInManager = signInManager;
            _userManager = userManager;

            _errorNotFound = "Your will could not be found.";
            _errorDefaultMessage = "It appears something went wrong. Please try again later. Should you still have the same issue, please get in touch with support.";
        }

        public void OnGet()
        {
            var user = _userManager.FindByNameAsync(HttpContext.User.Identity.Name);



            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                var x = 1;
            }
            else
            {
                var y = 2;
            }
        }
    }
}