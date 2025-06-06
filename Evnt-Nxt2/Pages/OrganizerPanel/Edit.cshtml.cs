using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.ViewModel;
using EvntNxtDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.OrganizerPanel
{
    public class EditModel : PageModel
    {
        private readonly OrganizerOverviewService _eventOverviewService;

        public List<OrganizerOverviewPanelDTO> Events { get; set; }
        public List<TicketTypeOverviewDTO> TicketTypes { get; set; }

        public EditModel(OrganizerOverviewService eventOverviewService, EventService eventService)
        {
            _eventOverviewService = eventOverviewService;
        }

        [BindProperty]
        public EventEditViewModel EditEvent { get; set; }


        public IActionResult OnGet(int id)
        {
            var userID = HttpContext.Session.GetInt32("ID");
            var roleID = HttpContext.Session.GetInt32("RoleID");
            var organizerID = HttpContext.Session.GetInt32("OrganizerID");


            if (organizerID == null || roleID != 2)
                return RedirectToPage("/Unauthorized");

            var dto = _eventOverviewService
                .GetEventsByOrganizerId(userID.Value)
                .FirstOrDefault(e => e.EventID == id);

            if (dto == null || dto.OrganizerID != organizerID.Value)
                return RedirectToPage("/Unauthorized");


            EditEvent = new EventEditViewModel
            {
                EventID = dto.EventID,
                EventName = dto.EventName,
                EventDate = dto.EventDate,
                EventLocation = dto.EventLocation,
                EventProvince = dto.EventProvince,
                OrganizerID = dto.OrganizerID,
                OrganizerUserID = dto.OrganizerUserID,
                TicketTypes = dto.TicketTypes.Select(t => new TicketTypeOverviewViewModel
                {
                    TicketType = t.TicketType,
                    AvailableTickets = t.AvailableTickets,
                    Price = t.Price
                }).ToList()
            };
            
            return Page();
        }
    }
}
