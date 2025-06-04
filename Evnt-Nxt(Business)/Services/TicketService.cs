using System.ComponentModel.DataAnnotations;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.Interfaces;
using EvntNxt.DTO;
using EvntNxtDTO;

namespace Evnt_Nxt_Business_.Services
{
    public class TicketService : ITicketService
    {
        public List<TicketDTO> TesTicketDtos = new();
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventTicketService _eventTicketService;
        private readonly UserService _userService;

        public TicketService(ITicketRepository ticketRepository, UserService userService, IEventTicketService eventTicketService)
        {
            _ticketRepository = ticketRepository;
            _userService = userService;
            _eventTicketService = eventTicketService;

        }


        public (bool Success, List<string> Errors) TryTicketPurchase(TicketPurchaseRequestDto request)
        {
            List<string> errors = new();

            // Checks for the right order amount
            if (request.Quantity < 1 || request.Quantity > 5)
                errors.Add("The ticket order quantity must be between 1 and 5.");
            
            // If the order amount is valid, the application gets the order
            var availableTickets = _eventTicketService.GetAvailableEventTickets(request.EventID);

            // Gives the ticket a unique ID
            var selectedTicket = availableTickets.FirstOrDefault(ticket => ticket.ID == request.TicketID);

            // Checks if the current ticket exists, and if there are enough tickets available
            if (selectedTicket == null)
            {
                errors.Add("Ticket does not exist.");
            }
            else
            {
                if (request.Quantity > selectedTicket.Amount || !selectedTicket.IsAvailable)
                    errors.Add("Not enough tickets available.");
            }

            if (errors.Any())
            {
                return (false, errors);
            }

            // If everything checks out the program creates the DTO
            var ticket = new TicketDTO
            {
                UserID = request.UserID,
                EventTicketID = request.TicketID,
                PurchaseDate = DateOnly.FromDateTime(DateTime.Today)
            };

            // Adds the Ticket to the User
            _ticketRepository.AddTicketToUser(ticket, request.Quantity);

            // Decreases the stock by the quantity
            _ticketRepository.DecreaseAvailableTickets(request.TicketID, request.Quantity);

            return (true, new List<string>());
        }

        public List<UserProfileTicketDTO> ValidateUserTicket(string username)
        {
            // Validates if the userID is correct
            var user = _userService.GetUserName(username);
            if (user == null)
            {
                return null;
            }

            // Gets all the tickets from the user
            var allTickets = _ticketRepository.GetTicketByUserID(user.ID);

            // Filters out duplicated tickets for the same event
            var uniqueEvents = allTickets
                .GroupBy(userTicket => userTicket.EventID)
                .Select(group => group.First())
                .ToList();

            return uniqueEvents;
        }
    }
}
