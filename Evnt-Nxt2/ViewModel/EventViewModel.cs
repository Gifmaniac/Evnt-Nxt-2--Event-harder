using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Enums;

namespace Evnt_Nxt_Business_.ViewModel
{
    public class EventViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Organizer Organizer { get; set; }
        public string Location { get; set; }
        public string Province { get; set; }
        public DateOnly Date { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
