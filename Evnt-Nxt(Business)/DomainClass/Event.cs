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
        public int ID { get; }
        public string Name { get; }
        public Organizer Organizer { get; }
        public string Location { get; }
        public ProvinceEnums Province { get; }
        public DateOnly Date { get; }

        public List<Genre> Genres { get; }

        public Event(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public Event(int id, string name, DateOnly date)
        {
            ID = id;
            Name = name;
            Date = date;
        }

        public Event(int id, string name, Organizer organizer, ProvinceEnums province, DateOnly date, List<Genre> genres)
        {
            ID = id;
            Name = name;
            Organizer = organizer;
            Province = province;
            Date = date;
            Genres = genres;
        }
    }
}
