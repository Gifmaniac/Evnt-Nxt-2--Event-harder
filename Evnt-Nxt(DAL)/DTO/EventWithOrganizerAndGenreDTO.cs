using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.DTO
{
    public class EventWithOrganizerAndGenreDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public string Province { get; set; }

        public OrganizerDTO Organizer { get; set; }
        public List<GenreDTO> Genre { get; set; } = new();
    }
}
