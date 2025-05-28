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

        public RegisterViewModel UserRegisterViewModel;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // TO DO Make the ViewModel in HTML

            var email = UserRegisterViewModel.Email;
            var username = UserRegisterViewModel.UserName;
            var password = UserRegisterViewModel.Password;
            var firstName = UserRegisterViewModel.FirstName;
            var lastName = UserRegisterViewModel.LastName;
            var birthday = UserRegisterViewModel.BirthDay;

            
            bool isValid = _registerService.VerifyRegister(email, username, password, firstName, lastName, birthday);

            // TO DO make the error list visible.
            if (!isValid)
            {
                return Page();
            }

            // TO DO if valid, create/ save user in database.
            return RedirectToPage("/Index");
        }
    }
}
