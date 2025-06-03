using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages
{
    public class ProfileModel : PageModel
    {
        public readonly UserService _userService;

        public ProfileModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty(SupportsGet = true)]
        public UserPageModel userPageModel { get; set; }

        //public IActionResult OnGet()
        //{
        //    //if (string.IsNullOrWhiteSpace(userPageModel.Username))
        //    //    return NotFound("Username not provided.");

        //    return null;
        //}
    }
}
