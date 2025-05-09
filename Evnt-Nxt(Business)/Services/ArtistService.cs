using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;


namespace Evnt_Nxt_Business_.Services
{
    public class ArtistService : IArtistService

    {
    private readonly IArtistRepository _artistRepo;
    private readonly IGenreRepository _genreRepo;

    public ArtistService(IArtistRepository artistRepo, IGenreRepository genreRepo)
    {
        _artistRepo = artistRepo;
        _genreRepo = genreRepo;
    }

    public List<ArtistDTO> GetAllArtists()
    {
        return _artistRepo.GetAllArtist();
    }


    public ArtistDTO GetArtistByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Artist name has not bin found please try again.");
        }

        return _artistRepo.GetArtistByName(name);
    }

    public List<Artist> CreateAllArtist()
    {
        var dtoList = _artistRepo.GetAllArtist();
        var artistList = new List<Artist>();

        foreach (var dto in dtoList)
        {
            var genreDtos = _genreRepo.GetGenresByArtistID(dto.ID);
            var genres = genreDtos.Select(g => new Genre(g.ID, g.Name)).ToList();
            var artist = new Artist(dto.ID, dto.Name, genres);
            artistList.Add(artist);
        }

        return artistList;
    }
    }
}
