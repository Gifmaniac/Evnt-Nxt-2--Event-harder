using EvntNxtDTO;
using System.ComponentModel.DataAnnotations;

namespace Evnt_Nxt2.ViewModel
{
    public class EventEditViewModel
    {
        public int EventID { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly EventDate { get; set; }
        [Required]
        public string EventLocation { get; set; }
        [Required]
        public string EventProvince { get; set; }
        [Required]
        public int OrganizerID { get; set; }

        public string OrganizerName { get; set; }

        public int OrganizerUserID { get; set; }

        public List<TicketTypeOverviewViewModel> TicketTypes { get; set; } = new();

        public List<string> Genres { get; set; } = new();

    }
}
