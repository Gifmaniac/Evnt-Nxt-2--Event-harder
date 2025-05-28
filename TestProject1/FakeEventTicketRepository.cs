using Evnt_Nxt_Business_.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class FakeEventTicketRepository
    {
        private readonly List<EventTicket> _tickets;

        public FakeEventTicketRepository(List<EventTicket> tickets)
        {
            _tickets = tickets;
        }
    }
}
