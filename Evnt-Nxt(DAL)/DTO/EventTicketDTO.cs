using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.DTO
{
    public class EventTicketDTO
    {
        public EventDTO Event { get; set; }
        public TicketDTO Ticket { get; set; }
    }
}
