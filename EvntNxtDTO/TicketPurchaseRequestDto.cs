using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvntNxtDTO
{
    public class TicketPurchaseRequestDto
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int TicketId { get; set; }
        public int Quantity { get; set; }
    }
}
