using System.Net;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;


namespace Evnt_Nxt_Business_.Services
{
    public class ArtistService

    {
        private readonly ArtistRepository _artistRepo;
        private readonly GenreRepository _genreRepo;
        private readonly ArtistGenreRepository _artistGenreRepo;

        public ArtistService(ArtistRepository artistRepo, GenreRepository genreRepo, ArtistGenreRepository artistGenreRepo)
        {
            _artistRepo = artistRepo;
            _genreRepo = genreRepo;
            _artistGenreRepo = artistGenreRepo;
        }


        public Artist GetArtistByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Artist name has not bin found please try again.");
            }
            var artist = _artistRepo.GetArtistByName(name);

            return new Artist(artist.ID, artist.Name);
        }

        public List<ArtistWithGenresDTO> GetAllArtistsWithGenres()
        {
            List<ArtistDTO> artistDtos = _artistRepo.GetAllArtistDtos();
            List<GenreDTO> genreDtos = _genreRepo.GetAllGenreDtos();
            List<ArtistGenreDTO> artistsGenreLinks = _artistGenreRepo.GetAllArtistGenreLinks();

            return ArtistGenreMapper.MapToDto(artistDtos, genreDtos, artistsGenreLinks);
        }

        public List<Artist> MapToDomain()
        {

        }
    }
}
