using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt2.Mapper;
using Evnt_Nxt2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Security.Claims;

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

            // Gets the user (currently hard coded since I dont have a login yet)
            var userID = User.FindFirst("userID")?.Value;
            int parsedID = int.Parse(userID);
            var currentUser = _userService.GetUserIDEmailFirstAndLastName(parsedID);

            //// Gets the available ticket from the event.
            //var availableTickets = _eventTicketService.GetAvailableEventTickets(EventID);
            //EventTickets = EventTicketsModelMapper.ToEventTicketsViewModelList(availableTickets);

            //// Sets the ID for the ticket that the user wants to buy
            //var selectedTicket = EventTickets.FirstOrDefault(ticket => ticket.ID == EventTicketID);

            //// Validates if there are tickets selected by the user and if there are enough tickets for the order.
            //if (TicketsToBuy < 1 || TicketsToBuy > 5 || TicketsToBuy > selectedTicket.Amount)
            //{
            //    ModelState.AddModelError("", "Invalid ticket selection or not enough tickets available.");
            //    return Page();
            //}
            //// Gets the user (currently hard coded since I dont have a login yet)
            //var userID = User.FindFirst("userID")?.Value;
            //int parsedID = int.Parse(userID);
            //var currentUser = _userService.GetUserIDEmailFirstAndLastName(parsedID);

            //// Checks if the purchase went through and the ticket has been created.
            //try
            //{
            //    _ticketService.BuyTicket(currentUser, selectedTicket.ID, TicketsToBuy);
            //    return RedirectToPage("TicketConfirmation");
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError("", "Something went wrong while processing your ticket.");
            //    return Page();
            //}

        }

    }
}
