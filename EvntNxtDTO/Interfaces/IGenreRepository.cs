using EvntNxt.DTO;

namespace Evnt_Nxt_DAL_.Interfaces
{
    public interface IGenreRepository
    {
        List<GenreDTO> GetGenresByArtistID(int artistId);
    }
}
