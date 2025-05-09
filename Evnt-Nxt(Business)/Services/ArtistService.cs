using System.Net;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;


namespace Evnt_Nxt_Business_.Services
{
    public class ArtistService

    {
        private readonly ArtistRepository _artistRepo;
        private readonly GenreRepository _genreRepo;

        public ArtistService(ArtistRepository artistRepo, GenreRepository genreRepo)
        {
            _artistRepo = artistRepo;
            _genreRepo = genreRepo;
        }


        public ArtistDTO GetArtistByName(string name)
        {


            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Artist name has not bin found please try again.");
            }

            var artistList = _artistRepo.GetArtistByName(name);
            return artistList;
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
