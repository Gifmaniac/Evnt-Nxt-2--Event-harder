﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvntNxtDTO
{
    public class TicketTypeOverviewDTO
    {
        public int TicketID { get; set; }
        public string TicketType { get; set; }
        public int AvailableTickets { get; set; }
        public int SoldTickets { get; set; }
        public decimal Price { get; set; }
    }
}