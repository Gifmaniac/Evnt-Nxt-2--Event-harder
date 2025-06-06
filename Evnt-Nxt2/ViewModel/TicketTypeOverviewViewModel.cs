namespace Evnt_Nxt2.ViewModel
{
    public class TicketTypeOverviewViewModel
    {
        public int TicketID { get; set; }
        public string TicketType { get; set; }
        public int AvailableTickets { get; set; }
        public int SoldTickets { get; set; }

        public decimal Price { get; set; }
    }
}
