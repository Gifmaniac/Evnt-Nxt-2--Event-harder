using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class Ticket
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EventTicketID { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
