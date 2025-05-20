using Evnt_Nxt_DAL_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class EventTicket
    {
        public Event Event { get; set; }
        public Ticket Ticket { get; set; }

        public EventTicket(Event @event, Ticket ticket)
        {
            Event = @event;
            Ticket = ticket;
        }
    }
}
