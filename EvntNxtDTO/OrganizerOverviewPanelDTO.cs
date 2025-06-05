using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvntNxtDTO
{
    public class OrganizerOverviewPanelDTO 
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateOnly EventDate { get; set; }
        public int OrganizerID { get; set; }
        public string OrganizerName { get; set; }
        public int OrganizerUserID { get; set; }
        public List<TicketTypeOverviewDTO> TicketTypes { get; set; } = new();
        public List<string> Genres { get; set; } = new();
    }
}
