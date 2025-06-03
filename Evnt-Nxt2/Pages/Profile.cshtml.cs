using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;
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

        public IActionResult OnGet()
        {
            if (string.IsNullOrWhiteSpace(UserPageModel.Username))
            {
                return NotFound();
            }

            try
            {
                Tickets = _ticketService.ValidateUserTicket(UserPageModel.Username);
                return Page();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
