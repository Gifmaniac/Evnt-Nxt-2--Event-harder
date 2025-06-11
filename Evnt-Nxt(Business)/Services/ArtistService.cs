using System.Net;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;


namespace Evnt_Nxt_Business_.Services
{
    public class ArtistService : IArtistService

    {
        private readonly ArtistRepository _artistRepo;
        private readonly GenreRepository _genreRepo;

        public ArtistService(ArtistRepository artistRepo, GenreRepository genreRepo)
        {
            _artistRepo = artistRepo;
            _genreRepo = genreRepo;
        }


        public (bool Success, string ErrorMessage, ArtistDTO? Artist) GetArtistByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return (false, "Artist name must be provided.", null);

            var artist = _artistRepo.GetArtistByName(name);

            if (artist == null)
                return (false, "Artist not found.", null);

            var dto = new ArtistDTO
            {
                ID = artist.ID,
                Name = artist.Name
            };

            return (true, null, dto);
        }

        public List<Artist> CreateAllArtistsWithGenre()
        {
            var dtoList = _artistRepo.GetArtistWithGenresList();
            var artistList = new List<Artist>();

            foreach (var dto in dtoList)
            {
                var genreList = dto.Genres.Select(genre => new Genre(genre.ID, genre.Name)).ToList();
                var artist = new Artist(dto.ID, dto.Name, genreList);
                artistList.Add(artist);
            }
            return artistList;
        }
    }
}
