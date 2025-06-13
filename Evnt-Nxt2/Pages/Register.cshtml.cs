using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;
using Evnt_Nxt2.Mapper;
<<<<<<< Updated upstream
using EvntNxt.DTO;
using EvntNxtDTO;
=======
using Evnt_Nxt_DAL_.DTO;
>>>>>>> Stashed changes


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
<<<<<<< Updated upstream

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
=======
            if (!ModelState.IsValid)
>>>>>>> Stashed changes
                return Page();

            UserDTO userDto = UserModelMapper.NewUser(UserRegisterViewModel);

            try
            {

                _registerService.VerifyRegister(userDto);
                _registerService.RegisterUser(userDto);

                return RedirectToPage("/Index");

            }
<<<<<<< Updated upstream
=======

            catch (Exception exception)

            {
                var messages = exception.Message.Split(" | ");

                foreach (var message in messages)
                {
                    ModelState.AddModelError(string.Empty, message);
                }

                return Page();
            }
>>>>>>> Stashed changes
        }
    }
}
