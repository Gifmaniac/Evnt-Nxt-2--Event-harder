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
        public int LineUpID { get; set; }
        public string Name { get; set; }
        public Genre GenreID { get; set; }
        public string Organizer { get; set; }
        public string Location { get; set; }
        public ProvinceMapper Province { get; set; }
        public DateOnly Date { get; set; }
        public int Price { get; set; }

    }
}
