using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.DTO
{
    public class BuyTicketFromEventDTO
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public int Price { get; set; }
        public EventDTO Event { get; set; }
    }
}
