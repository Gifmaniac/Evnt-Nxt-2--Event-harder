using EvntNxt.DTO;

namespace Evnt_Nxt_DAL_.Interfaces
{
    public interface IArtistRepository
    {
        public List<ArtistWithGenresDTO> GetArtistWithGenresList();
        public ArtistDTO GetArtistByName(string name);
    }
}
