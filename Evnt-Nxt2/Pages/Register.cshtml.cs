using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;
using Evnt_Nxt2.Mapper;
using EvntNxt.DTO;
using EvntNxtDTO;


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

            if (!ModelState.IsValid)
                return Page();

            RegisterDTO userDto = new RegisterDTO
            {
                Email = UserRegisterViewModel.Email,
                Password = UserRegisterViewModel.Password,
                UserName = UserRegisterViewModel.UserName,
                BirthDay = UserRegisterViewModel.BirthDay,
                FirstName = UserRegisterViewModel.FirstName,
                LastName = UserRegisterViewModel.LastName,
            };

            try
            {
                // Validates all the register info
                _registerService.VerifyRegister(userDto);

                // If validated registers the user with all the register info
                _registerService.RegisterUser(userDto);

                return RedirectToPage("/Index");
            }

            catch(ArgumentException exception)
            {
                var errors = exception.Message.Split(" | ");
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return Page();
            }
        }
    }
}
