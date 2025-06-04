using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_;
using EvntNxt.DTO;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;

namespace Evnt_Nxt2.Pages.OrganizerPanel
{
    public class OrganizerPanelModel : PageModel
    {
        private readonly OrganizerOverviewService _eventOverviewService;

        public List<OrganizerOverviewDTO> Events { get; set; }

        public OrganizerPanelModel()
        {
            _eventOverviewService = new OrganizerOverviewService();
        }

        public IActionResult OnGet()
        {
            var sessionUserID = HttpContext.Session.GetInt32("UserID");
            var sessionRoleID = HttpContext.Session.GetInt32("RoleID");

            if (sessionUserID == null || sessionRoleID != 2)
                return RedirectToPage("/Login");

            Events = _eventOverviewService.GetEventsByOrganizerId(sessionUserID.Value);

            return Page();
        }
    }
}