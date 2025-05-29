using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_DAL_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Mapper
{
    public static class TicketMapper
    {
        public static Ticket ToDomain(int userId, int eventTicketId, DateOnly purchaseDate)
        {
            return new Ticket(userId, eventTicketId, purchaseDate);
        }

        public static TicketDTO ToDto(Ticket ticket)
        {
            return new TicketDTO
            {
                UserID = ticket.UserID,
                EventTicketID = ticket.EventTicketID,
                PurchaseDate = ticket.PurchaseDate
            };
        }
    }
}
