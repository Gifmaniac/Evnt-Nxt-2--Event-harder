using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Services
{
    public class TicketService : ITicketService
    {
        public List<TicketDTO> TesTicketDtos = new();
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
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
