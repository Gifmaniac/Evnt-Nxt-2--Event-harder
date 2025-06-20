using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class Genre
    {
        public int ID { get; }
        public string Name { get; }

        public Genre(int id, string name)
        {
            ID = id;
            Name = name;
        }

    }
}
