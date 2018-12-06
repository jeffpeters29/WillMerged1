using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;
using System.Linq;

namespace Qwill.Pages
{
    public class Step2Model : PageModel
    {
        //private readonly IWillVmService _willVmService;
        //private readonly IAppLogger<Step2Model> _logger;

        //private readonly string _errorNotFound;
        //private readonly string _errorDefaultMessage;

        //public Step2Model(IWillVmService willVmService, IAppLogger<EditModel> appLogger)
        //{
        //    _willVmService = willVmService;
        //    _logger = appLogger;

        //    _errorNotFound = "Your will could not be found.";
        //    _errorDefaultMessage = "It appears something went wrong. Please try again later. Should you still have the same issue, please get in touch with support.";
        //}

        //[BindProperty]
        //public WillVm WillInfo { get; set; } = new WillVm();

        //[TempData]
        //public string ErrorMessage { get; set; }

        //public void OnGet(Guid id)
        //{
        //    try
        //    {
        //        WillInfo = _willVmService.Get(id);

        //        //Sample data
        //        WillInfo.Children.Add(new Child() { Id = Guid.NewGuid(), FirstName = "Adam", Over18 = false });
        //        WillInfo.Children.Add(new Child() { Id = Guid.NewGuid(), FirstName = "Brian", Over18 = true });
        //        WillInfo.Children.Add(new Child() { Id = Guid.NewGuid(), FirstName = "Chris", Over18 = true });
        //    }
        //    catch (ArgumentNullException e)
        //    {
        //        _logger.LogWarning("Step2 OnGet exception", e.Message);
        //        ErrorMessage = _errorNotFound;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogWarning("Step2 OnGet exception", e.Message);
        //        ErrorMessage = _errorDefaultMessage;
        //    }
        //}

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var willId = _willVmService.Post(WillInfo);

        //    //Success
        //    if (willId != null) return RedirectToPage("/Step3/" + willId.Value);

        //    //Error
        //    _logger.LogWarning("Step2 OnPost exception", _errorDefaultMessage);
        //    return Page();
        //}

        //public IActionResult OnPostSaveChildDetails([FromBody]ChildVm childData)
        //{
        //    WillInfo = _willVmService.Get(childData.WillId);

        //    if (childData.ChildId.Value.IsGuid())
        //    {
        //        var child = WillInfo.Children.FirstOrDefault(c => c.Id == childData.ChildId);
        //        WillInfo.Children.Remove(child);
        //    }

        //    WillInfo.Children.Add(new Child() { FirstName = childData.ChildName, Over18 = childData.Over18 });

        //    return new JsonResult("true");
        //}
    }
}