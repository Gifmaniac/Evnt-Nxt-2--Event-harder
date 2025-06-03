using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt2.Mapper;
using Evnt_Nxt2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvntNxtDTO;

namespace Evnt_Nxt2.Pages
{
    public class TicketModel : PageModel
    {
        private readonly IEventTicketService _eventTicketService;
        private readonly EventService _eventService;
        private readonly ITicketService _ticketService;
        private readonly UserService _userService;

        [BindProperty]
        public int EventID { get; set; }
        [BindProperty]
        public int TicketsToBuy { get; set; }
        [BindProperty]
        public int EventTicketID { get; set; }

        public List<EventTicketViewModel> EventTickets { get; set; } = new();
        public EventViewModel Event { get; set; }

        public TicketModel(IEventTicketService eventTicketService, EventService eventService, UserService userService, ITicketService ticketService)
        {
            _eventTicketService = eventTicketService;
            _eventService = eventService;
            _userService = userService;
            _ticketService = ticketService;
        }

        public void OnGet(int eventID)
        {
            EventID = eventID;

            var @event = _eventService.GetEventByID(eventID);
            Event = EventViewModelMapper.ToEventViewModel(@event);

            var availableTickets = _eventTicketService.GetAvailableEventTickets(eventID);
            EventTickets = EventTicketsModelMapper.ToEventTicketsViewModelList(availableTickets);
        }

        public IActionResult OnPost()
        {
            var userRequest = new TicketPurchaseRequestDto
            {
                UserId = 1, // placeholder
                EventId = EventID,
                TicketId = EventTicketID,
                Quantity = TicketsToBuy
            };

            try
            {
                _ticketService.TryTicketPurchase(userRequest);
                return RedirectToPage("/Index");
            }
            catch (ArgumentException exception)
            {
                foreach (var error in exception.Message.Split(" | "))
                    ModelState.AddModelError(string.Empty, error);

                return Page();
            }
        }
    }
}
