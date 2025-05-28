using Evnt_Nxt_Business_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt2.ViewModel;

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


        [BindProperty] public LoginViewModel UserLogin { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            bool isLoginValid = _loginService.VerifyLogin(UserLogin.Email, UserLogin.Password);
            var user = _userService.GetByEmail(UserLogin.Email);

            if (isLoginValid)
            {
                // To Do Work on sessions/ cookies.
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
