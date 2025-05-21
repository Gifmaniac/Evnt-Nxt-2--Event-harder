using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt2.Mapper;
using Evnt_Nxt2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages
{
    public class TicketModel : PageModel
    {
        private readonly IEventTicketService _eventTicketService;
        private readonly EventService _eventService;
        public List<EventTicketViewModel> EventTickets { get; set; } = new();
        public EventViewModel Event { get; set; }

        public TicketModel(IEventTicketService eventTicketService, EventService eventService)
        {
            _eventTicketService = eventTicketService;
            _eventService = eventService;
        }

        public void OnGet(int eventID)
        {
            var @event = _eventService.GetEventByID(eventID);
            Event = EventViewModelMapper.ToEventViewModel(@event);

            var availableTickets = _eventTicketService.GetAvailableEventTickets(eventID);
            EventTickets = EventTicketsModelMapper.ToEventTicketsViewModelList(availableTickets);
        }
    }
}
