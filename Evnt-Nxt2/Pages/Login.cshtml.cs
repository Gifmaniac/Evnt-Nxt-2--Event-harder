using Evnt_Nxt_Business_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt2.ViewModel;
using Microsoft.AspNetCore.Http;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt2.Mapper;
using EvntNxtDTO;

namespace Evnt_Nxt2.Pages
{
    public class LoginModel : PageModel
    {
        private readonly LoginService _loginService;

        public LoginModel(LoginService loginService)
        {
            _loginService = loginService;
        }


        [BindProperty] 
        public LoginViewModel UserLogin { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var loginDto = new LoginDTO
            {
                Email = UserLogin.Email,
                Password = UserLogin.Password
            };

            try
            {
                // Validates the Login (Email + Password)
                _loginService.ValidateLogin(loginDto);
                
                // If Validated, this gets the login info (ID, UserName, RoleID)
                LoggedInUserDTO user = _loginService.GetLoginInfo(loginDto.Email);
                HttpContext.Session.SetInt32("UserID", user.ID );
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetInt32("RoleID", user.RoleID);

                return RedirectToPage("/Index");
            }

            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return Page();
            }
        }
    }
}
