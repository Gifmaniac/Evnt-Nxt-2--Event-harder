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
                var result = _loginService.ValidateLogin(loginDto);

                if (!result.Success)
                {
                    ModelState.AddModelError(string.Empty, result.ErrorMessage);
                    return Page();
                }

                var validatedDto = _loginService.GetLoginInfo(loginDto.Email);

                // Login has been validated, the user session is created.
                HttpContext.Session.SetInt32("UserID", validatedDto.ID);
                HttpContext.Session.SetString("UserName", validatedDto.UserName);
                HttpContext.Session.SetInt32("RoleID",validatedDto.RoleID);

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong, please try again later.");
                return Page();
            }
        }
    }
}
