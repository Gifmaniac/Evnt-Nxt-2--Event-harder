using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;


namespace Evnt_Nxt2.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly RegisterService _registerService;

        public RegisterModel(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [BindProperty] 
        public RegisterViewModel UserRegisterViewModel { get; set; }

        public void OnGet()
        {
            UserRegisterViewModel = new RegisterViewModel();
        }

        public IActionResult OnPost()
        {

            bool isValid = _registerService.VerifyRegister(UserRegisterViewModel.Email, UserRegisterViewModel.UserName,
                UserRegisterViewModel.Password);

            if (!isValid)
            {
                List<string> errors = _registerService.GetValidationErrors(UserRegisterViewModel.Email, UserRegisterViewModel.UserName, UserRegisterViewModel.Password);
                return Page();
            }

            _registerService.RegisterUser(UserRegisterViewModel.Email, UserRegisterViewModel.UserName,
                UserRegisterViewModel.Password, UserRegisterViewModel.FirstName, UserRegisterViewModel.LastName,
                UserRegisterViewModel.BirthDay);

            return RedirectToPage("/Index");
        }
    }
}
