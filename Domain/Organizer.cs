using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class Organizer
    {
        public int ID { get; }
        public string Name { get; }
        public int Tel { get; }

        public Organizer(int iD, string name, int tel)
        {
            ID = iD;
            Name = name;
            Tel = tel;
        }
    }
}
