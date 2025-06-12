using Evnt_Nxt_Business_.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Interfaces;

namespace TestProject1
{
    public class FakeEventTicketRepository : IEventTicketService
    {
        private readonly List<EventTicket> _tickets;

        public FakeEventTicketRepository()
        {
            _tickets = new List<EventTicket>
            {
                new EventTicket(1, "Regular", 25.00m, 50, true),
                new EventTicket(2, "VIP", 50.00m, 0, false),
                new EventTicket(3, "Backstage", 100.00m, 10, true)
            };
        }

        public List<EventTicket> GetAvailableEventTickets(int eventId)
        {
            return _tickets.Where(t => t.IsAvailable && t.Amount > 0).ToList();
        }

        public List<EventTicket> CreateEventTicketWithEventIDNameAndDate()
        {
            return null;
        }
    }
}
