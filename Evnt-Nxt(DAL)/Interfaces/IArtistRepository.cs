using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_.DTO;

namespace Evnt_Nxt_DAL_.Interfaces
{
    public interface IArtistRepository
    {
        public List<ArtistWithGenresDTO> GetArtistWithGenresList();
        public ArtistDTO GetArtistByName(string name);
    }
}
