using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketRepository _ticketRepository;

        public TicketService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public void BuyTicket(User user, int eventID, int quantity)
        {
            if (user == null || eventID == null || quantity < 1)
            {
                return;
            }

            for (int i = 0; i < quantity; i++)
            {
                TicketDTO ticket = new TicketDTO
                {
                    UserID = user.ID,
                    EventTicketID = eventID,
                    PurchaseDate = DateOnly.FromDateTime(DateTime.Today)
                };
                _ticketRepository.AddTicketToUser(ticket);
            }
        }
    }
}
