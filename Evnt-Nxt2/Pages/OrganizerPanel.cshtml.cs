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

        public IActionResult OnGet()
        {
            var organizerID = HttpContext.Session.GetInt32("ID");
            var roleID = HttpContext.Session.GetInt32("RoleID");

            if (organizerID == null || (Roles)roleID != Roles.Organizer)
            {
                return RedirectToPage("/Unauthorized");
            }


            Events = _eventOverviewService.GetEventsByOrganizerId(organizerID.Value);

            return Page();
        }
    }

}
