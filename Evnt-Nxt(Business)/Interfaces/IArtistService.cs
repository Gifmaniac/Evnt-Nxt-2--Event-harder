using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evnt_Nxt_Business_.DomainClass;


namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IArtistService
    {
        public List<Artist> CreateAllArtist();
    }
}
