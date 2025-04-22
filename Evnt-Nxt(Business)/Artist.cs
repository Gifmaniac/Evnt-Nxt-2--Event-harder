using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_
{
    class Artist
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private List<Genre> Genres { get; set; }

        public string GetArtistName()
        {
            return this.Name;
        }

        public List<Genre> GetArtistGenres()
        {
            return this.Genres;
        }

        public int GetArtistID()
        {
            return this.ID;
        }
    }
}
