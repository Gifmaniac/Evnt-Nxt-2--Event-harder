using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IEventTicketService
    {
        public List<EventTicket> GetAvailableEventTickets(int eventId);
        public List<EventTicket> CreateEventTicketWithEventIDNameAndDate();
    }
}
