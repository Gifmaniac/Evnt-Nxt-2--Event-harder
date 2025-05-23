using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.ViewModel;

namespace Evnt_Nxt2.ViewModel
{
    public class EventTicketViewModel
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool IsAvailable { get; set; }

        public Event Event { get; set; }
        public Ticket Ticket { get; set; }

    }
}
