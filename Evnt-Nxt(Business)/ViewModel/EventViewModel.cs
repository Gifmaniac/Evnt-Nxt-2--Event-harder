using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Enums;

namespace Evnt_Nxt_Business_.ViewModel
{
    public class EventViewModel
    {
        public int ID { get; set; }
        public int LineUpID { get; set; }
        public string Name { get; set; }
        public int GenreID { get; set; }
        public string Organizer { get; set; }
        public string Location { get; set; }
        public ProvinceEnums Province { get; set; }
        public DateOnly Date { get; set; }
        public int Price { get; set; }
    }
}
