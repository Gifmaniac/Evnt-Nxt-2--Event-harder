using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.Interfaces
{
    public interface IArtistRepository
    {
        List<ArtistDTO.ArtistDTO> GetArtistDtos();

        ArtistDTO.ArtistDTO GetArtistByName(string Name);
        //void AddArtist(ArtistDTO.ArtistDTO Artist);
        //void UpdateArtist(ArtistDTO.ArtistDTO Artist);

        //void DeleteArtist(int ID);
    }
}
