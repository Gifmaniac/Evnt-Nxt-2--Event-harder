using Evnt_Nxt_Business_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt2.ViewModel;
using Microsoft.AspNetCore.Http;

namespace Evnt_Nxt2.Pages
{
    public class LoginModel : PageModel
    {
        private readonly LoginService _loginService;
        private readonly UserService _userService;

        public LoginModel(LoginService loginService, UserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }


        [BindProperty] 
        public LoginViewModel UserLogin { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        { 

            bool isLoginValid = _loginService.VerifyLogin(UserLogin.Email, UserLogin.Password);

            var user = _userService.GetByEmail(UserLogin.Email);

            if (isLoginValid)
            {
                HttpContext.Session.SetInt32("UserID", user.ID);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetInt32("RoleID", user.RoleID);
                return RedirectToPage("/Index");
            }

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return Page();
            }

            return Page();
        }
    }
}
