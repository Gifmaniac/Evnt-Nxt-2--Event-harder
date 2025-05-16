using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.DTO
{
    public class EventDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int OrganizerID { get; set; }
        public OrganizerDTO Organizer { get; set; }
        public string Province { get; set; }
        public DateOnly Date { get; set; }
        public List<GenreDTO> Genres { get; set; } = new();
    }
}
