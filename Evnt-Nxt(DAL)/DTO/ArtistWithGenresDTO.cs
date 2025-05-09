using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.DTO
{
    public class ArtistWithGenresDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GenreDTO> Genres { get; set; } = new();
    }
}
