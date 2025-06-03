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

        public TicketPurchaseValidator TryTicketPurchase(TicketPurchaseRequestDto request)
        {
            List<EventTicket> availableTickets = _eventTicketService.GetAvailableEventTickets(request.EventId);

            EventTicket selectedTicket = availableTickets.FirstOrDefault(ticket => ticket.ID == request.TicketId);

            List<string>errors = TicketPurchaseValidator.Validate(request, selectedTicket);

            if (!errors.Any())
                return errors;
        }

        public void BuyTicket(User user, int eventTicketID, int quantity)
        {
            if (user == null || eventTicketID == null || quantity < 1)
            {
                return;
            }

            for (int i = 0; i < quantity; i++)
            {
                var ticket = new TicketDTO
                {
                    UserID = user.ID,
                    EventTicketID = eventTicketID,
                    PurchaseDate = DateOnly.FromDateTime(DateTime.Today)
                };

                _ticketRepository.AddTicketToUser(ticket, 1);
                _ticketRepository.DecreaseAvailableTickets(eventTicketID, 1);
            }
        }
    }
}
