using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;

namespace Evnt_Nxt_Business_.Services
{
    public class TicketService : ITicketService
    {
        public void BuyTicket(User user, EventTicket eventTicket)
        {
            user.PurchasedTickets.Add(eventTicket.Ticket);
        }
    }
}
