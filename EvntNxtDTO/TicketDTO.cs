namespace EvntNxt.DTO
{
    public class TicketDTO
    {  
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EventTicketID { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
