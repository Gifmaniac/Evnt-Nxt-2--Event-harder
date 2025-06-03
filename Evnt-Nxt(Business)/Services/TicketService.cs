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
        public void TryTicketPurchase(TicketPurchaseRequestDto request)
        {
            if (request.Quantity < 1 || request.Quantity > 5)
                throw new ArgumentException("The ticket order quantity must be between 1 and 5.");

            var availableTickets = _eventTicketService.GetAvailableEventTickets(request.EventId);
            var selectedTicket = availableTickets.FirstOrDefault(ticket => ticket.ID == request.TicketId);

            List<string> errors = new();

            if (selectedTicket == null)
                errors.Add("Ticket does not exist.");

            if (selectedTicket != null && request.Quantity > selectedTicket.Amount)
                errors.Add("Not enough tickets available.");

            if (errors.Any())
                throw new ArgumentException(string.Join(" | ", errors));


            var user = _userService.GetUserIDEmailFirstAndLastName(request.UserId);

            // Create DTO
            var ticket = new TicketDTO
            {
                UserID = request.UserId,
                EventTicketID = request.TicketId,
                PurchaseDate = DateOnly.FromDateTime(DateTime.Today)
            };

            _ticketRepository.AddTicketToUser(ticket, request.Quantity);
            _ticketRepository.DecreaseAvailableTickets(request.TicketId, request.Quantity);
        }
    }
}
