using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.ArtistDTO;


namespace Evnt_Nxt_Business_
{
    public class ArtistBll
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private List<Genre> Genres { get; set; }


        private readonly ArtistRepository artistRepo;

        public ArtistBll()
        {
            artistRepo = new ArtistRepository();
        }

        // Creates the artist "object"
        public ArtistBll(ArtistDTO dto)
        {
            ID = dto.ID;
            Name = dto.Name;
        }

        // Converts the information that the database hold in order to make an object. 
        public List<ArtistBll> GetAllArtistsList()
        {
            var dtos = artistRepo.GetAllArtist();
            var result = new List<ArtistBll>();

            foreach (var dto in dtos)
            {
                var artist = new ArtistBll(dto);
                result.Add(artist);
            }
            return result;
        }
    }
}
