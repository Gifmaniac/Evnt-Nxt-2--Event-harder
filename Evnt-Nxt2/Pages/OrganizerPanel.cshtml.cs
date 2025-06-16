using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Services;
using EvntNxtDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages
{
    public class OrganizerPanelModel : PageModel
    {
        private readonly OrganizerOverviewService _eventOverviewService;

        public List<OrganizerOverviewPanelDTO> Events { get; set; }

        public OrganizerPanelModel(OrganizerOverviewService eventOverviewService )
        {
            _eventOverviewService = eventOverviewService;
        }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            var userID = HttpContext.Session.GetInt32("ID");
            var roleID = HttpContext.Session.GetInt32("RoleID");

            if (userID == null || (Roles)roleID != Roles.Organizer)
            {
                return RedirectToPage("/Unauthorized");
            }


            Events = _eventOverviewService.GetEventsByOrganizerID(userID.Value);

            return Page();
        }

        public IActionResult OnPostDelete(int eventId)
        {
            var userID = HttpContext.Session.GetInt32("ID");
            var roleId = HttpContext.Session.GetInt32("RoleID");
            var organizerID = HttpContext.Session.GetInt32("OrganizerID");

            if (organizerID == null || (Roles)roleId != Roles.Organizer)
            {
                return RedirectToPage("/Unauthorized");
            }

            var result = _eventOverviewService.DeleteEvent(eventId, userID.Value, organizerID.Value);

            if (!result.Success)
            {
                ErrorMessage = result.Errors.FirstOrDefault();
                Events = _eventOverviewService.GetEventsByOrganizerID(organizerID.Value);
                return Page();
            }

            return RedirectToPage(); // reloads the same page, now with the event deleted
        }
    }


}
