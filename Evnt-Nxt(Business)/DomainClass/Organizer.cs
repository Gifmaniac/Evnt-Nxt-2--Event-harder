using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class Organizer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Tel { get; set; }

        public Organizer(int iD, string name, int tel)
        {
            ID = iD;
            Name = name;
            Tel = tel;
        }
    }
}
