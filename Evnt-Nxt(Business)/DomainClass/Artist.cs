using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class Artist
    {
        public int ID { get; }
        public string Name { get;}

        public List<Genre> Genre { get; }

        public Artist(int id, string name, List<Genre> genre)
        {
            ID = id;
            Name = name;
            Genre = genre;
        }
    }
}
