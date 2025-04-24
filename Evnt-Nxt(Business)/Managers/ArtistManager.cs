using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Model;
using Evnt_Nxt_DAL_.Repository;


namespace Evnt_Nxt_Business_.Managers
{
    public class ArtistManager
    {
        private readonly ArtistRepository artistRepo;
       

        public ArtistManager()
        {
            artistRepo = new ArtistRepository();
        }

        // Creates an artist "Object" from the dto.
        public List<ArtistViewModel> CreateArtists()
        {
            var dtos = artistRepo.GetArtistDtos();
            var result = new List<ArtistViewModel>();

            foreach (var dto in dtos)
            {
                result.Add(new ArtistViewModel
                {
                    ID = dto.ID,
                    Name = dto.Name
                });
            }
            return result;
        }

        public ArtistViewModel GetArtistByID(int id)
        {
            var artists = CreateArtists();
            return artists.FirstOrDefault(a => a.ID == id);
        }
    }
}
