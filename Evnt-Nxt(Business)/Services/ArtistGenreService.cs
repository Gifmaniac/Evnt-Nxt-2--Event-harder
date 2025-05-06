using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_Business_.Model;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Managers
{
    public class ArtistGenreService
    {
        private readonly ArtistGenreRepository ArtistGenreRepo;

        public ArtistGenreService(ArtistGenreRepository ArtistGenrerepo)
        {
            ArtistGenreRepo = ArtistGenrerepo;
        }
        public List<ArtistGenreViewModel> CreateArtistsGenre()
        {
            var dtos = ArtistGenreRepo.GetArtistGenresDTOs();
            var result = new List<ArtistGenreViewModel>();

            foreach (var dto in dtos)
            {
                result.Add(new ArtistGenreViewModel
                {
                    ArtistID = dto.ArtistID,
                    ArtistName = dto.ArtistName,
                    GenreID = dto.GenreID,
                    GenreName = GenreMapper.ToEnum(dto.GenreName)
                });
            }
            return result;
        }
    }
}
