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
                var result = _registerService.VerifyRegister(userDto);

                if (!result.succes)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    return Page();
                }
                _registerService.RegisterUser(userDto);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong. Please try again later.");
                return Page();
            }
        }
    }
}
