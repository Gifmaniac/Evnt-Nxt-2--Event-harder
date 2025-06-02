

namespace EvntNxt.DTO
{
    public class EventTicketDTO
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool IsAvailable { get; set; }

        public EventDTO Event { get; set; }
        public TicketDTO Ticket { get; set; }


    }
}
