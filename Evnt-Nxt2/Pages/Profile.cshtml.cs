using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;
using EvntNxt.DTO;
using EvntNxtDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserService _userService;
        private readonly ITicketService _ticketService;

        public ProfileModel(UserService userService, ITicketService ticketService)
        {
            _userService = userService;
            _ticketService = ticketService;
        }

        [BindProperty(SupportsGet = true)]
        public UserPageModel UserPageModel { get; set; }

        public List<UserProfileTicketDTO> Tickets { get; set; } = new();

        public IActionResult OnGet(string username)
        {

            if (string.IsNullOrWhiteSpace(UserPageModel.Username))
            {
                return NotFound();
            }

            UserDTO user;

            try
            {
                user = _userService.GetUserName(username); // if this fails, redirect
                UserPageModel.Username = user.Username;
            }
            catch
            {
                return RedirectToPage("/Index");
            }

            try
            {
                Tickets = _ticketService.ValidateUserTicket(user.Username); // if this fails, stay on page
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Something went wrong while loading tickets.");
            }

            return Page();
        }
    }
}
