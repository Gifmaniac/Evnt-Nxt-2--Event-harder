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
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
