using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Model;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IArtistService
    {
        List<ArtistViewModel> CreateArtist();
    }
}
