using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evnt_Nxt_Business_.DomainClass;
using EvntNxt.DTO;


namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IArtistService
    {
        public (bool Success, string ErrorMessage, ArtistDTO? Artist) GetArtistByName(string name);
        public List<Artist> CreateAllArtistsWithGenre();
    }
}
