using EvntNxtDTO;

namespace Evnt_Nxt2.ViewModel
{
    public class OrganizerOverviewDTO
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateOnly EventDate { get; set; }
        public int OrganizerID { get; set; }
        public string OrganizerName { get; set; }
        public List<TicketTypeOverviewDTO> TicketTypes { get; set; } = new();
        public List<string> Genres { get; set; } = new();
    }
}
