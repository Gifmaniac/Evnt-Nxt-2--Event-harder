using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvntNxtDTO
{
    public class TicketPurchaseRequestDto
    {
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int TicketID { get; set; }
        public int Quantity { get; set; }
    }
}
