using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.DTO
{
    public class TicketDTO
    {  
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EventTicketID { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
