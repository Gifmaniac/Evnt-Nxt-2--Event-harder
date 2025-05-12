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

        public List<Genre> Genres { get; set; } = new();

        public Artist(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public Artist(int id, string name, List<Genre> genres)
        {
            ID = id;
            Name = name;
            Genres = genres;
        }
    }
}
