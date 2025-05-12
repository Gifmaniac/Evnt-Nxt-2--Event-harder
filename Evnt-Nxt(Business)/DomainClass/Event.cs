using Evnt_Nxt_Business_.Enums;
using Evnt_Nxt_Business_.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Organizer OrganizerID { get; set; }
        public string Location { get; set; }
        public ProvinceEnums Province { get; set; }
        public DateOnly Date { get; set; }

        public List<Genre> Genres { get; set; }

        public Event(int id, string name, Organizer organizer, ProvinceEnums province, DateOnly date, List<Genre> genres)
        {
            ID = id;
            Name = name;
            OrganizerID = organizer;
            Province = province;
            Date = date;
            Genres = genres;
        }
    }
}
