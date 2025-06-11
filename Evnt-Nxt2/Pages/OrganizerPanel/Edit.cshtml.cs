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

            // TODO: RoleID aanpassen naar enums
            if (organizerID == null || roleID != 2)
            {
                return RedirectToPage("/Unauthorized");
            }

            var eventDTO = _eventOverviewService
                .GetEventsByOrganizerId(userID.Value)
                .FirstOrDefault(e => e.EventID == id);

            if (eventDTO == null || eventDTO.OrganizerID != organizerID.Value)
            {
                return RedirectToPage("/Unauthorized");
            }


            EditEvent = new EventEditViewModel
            {
                EventID = eventDTO.EventID,
                EventName = eventDTO.EventName,
                EventDate = eventDTO.EventDate,
                EventLocation = eventDTO.EventLocation,
                EventProvince = eventDTO.EventProvince,
                OrganizerID = eventDTO.OrganizerID,
                OrganizerUserID = eventDTO.OrganizerUserID,
                TicketTypes = eventDTO.TicketTypes.Select(t => new TicketTypeOverviewViewModel
                {
                    TicketType = t.TicketType,
                    AvailableTickets = t.AvailableTickets,
                    Price = t.Price
                }).ToList()
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            var userID = HttpContext.Session.GetInt32("ID");
            var roleID = HttpContext.Session.GetInt32("RoleID");
            var organizerID = HttpContext.Session.GetInt32("OrganizerID");

            var eventEditDTO = new OrganizerOverviewPanelDTO()
            {
                EventID = EditEvent.EventID,
                EventName = EditEvent.EventName,
                EventDate = EditEvent.EventDate,
                EventLocation = EditEvent.EventLocation,
                EventProvince = EditEvent.EventProvince,
                OrganizerID = EditEvent.OrganizerID,
                OrganizerUserID = EditEvent.OrganizerUserID,
                TicketTypes = EditEvent.TicketTypes.Select(t => new TicketTypeOverviewDTO
                {
                    TicketType = t.TicketType,
                    AvailableTickets = t.AvailableTickets,
                    Price = t.Price
                }).ToList(),
                Genres = EditEvent.Genres
            };

            if (organizerID == null || roleID != 2)
            {
                return RedirectToPage("/Unauthorized");
            }

            if (eventEditDTO.OrganizerID != organizerID.Value)
            {
                return RedirectToPage("/Unauthorized");
            }


            _eventOverviewService.UpdateEvent(eventEditDTO);
            ViewData["SuccessMessage"] = "Changes have been successfully saved.";

            return Page();
        }
    }
}
