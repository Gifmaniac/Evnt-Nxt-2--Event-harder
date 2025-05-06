using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Model;
using Evnt_Nxt_DAL_.Repository;


namespace Evnt_Nxt_Business_.Managers
{
    public class ArtistService : IArtistService
    {
        private readonly ArtistRepository ArtistRepo;
        private readonly ArtistGenreRepository ArtistGenreRepo;

        public ArtistService(ArtistRepository artistRepo, ArtistGenreRepository artistGenreRepository)
        {
            ArtistRepo = artistRepo;
            ArtistGenreRepo = artistGenreRepository;
        }

        // Creates an artist "Object" from the dto.
        public List<ArtistViewModel> CreateArtist()
        {
            var dtos = ArtistRepo.GetArtistDtos();
            var artistGenres = ArtistGenreRepo.GetArtistGenresDTOs();
            var Result = new List<ArtistViewModel>();

            foreach (var dto in dtos)
            {
                var genres = artistGenres
                    .Where(artistGenres => artistGenres.ArtistID == dto.ID)
                    .Select(artistGenres => artistGenres.GenreName)
                    .Distinct()
                    .ToList();
                Result.Add(new ArtistViewModel
                {
                    ID = dto.ID,
                    Name = dto.Name,
                    Genres = genres
                });
            }
            return Result;
        }
    }
}
