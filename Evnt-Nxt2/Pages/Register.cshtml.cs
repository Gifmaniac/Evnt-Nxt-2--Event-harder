using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;
using Evnt_Nxt2.Mapper;
using EvntNxt.DTO;


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

            UserDTO userDto = UserModelMapper.RegisterDto(UserRegisterViewModel);

            try
            {
                _registerService.VerifyRegister(userDto);
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
