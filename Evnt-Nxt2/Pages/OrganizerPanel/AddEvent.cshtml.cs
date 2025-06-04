using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt2.ViewModel;
using EvntNxt.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.OrganizerPanel
{
    public class AddEventModel : PageModel
    {
        private readonly EventService _eventService;

        [BindProperty]
        public List<EventWithOrganizerAndGenreDTO> Events { get; set; }

        public AddEventModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public OrganizerPanelViewModel EventOrganizer { get; set; }

        public IActionResult OnGet()
        {
            var organizerId = HttpContext.Session.GetInt32("UserID");
            var roleId = HttpContext.Session.GetInt32("RoleID");

            if (organizerId == null || roleId != 2)
            {
                return RedirectToPage("/Unauthorized");
            }

            EventOrganizer = new OrganizerPanelViewModel
            {
                Events = _eventService.GetEventsForOrganizerPanel(organizerId.Value),
                OrganizerName = HttpContext.Session.GetString("UserName")
            };
            return Page();
        }
    }
}
