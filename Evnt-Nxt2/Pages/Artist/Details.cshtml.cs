using Evnt_Nxt_Business_.Managers;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Model;

namespace Evnt_Nxt2.Pages.Artist
{
    public class DetailsModel : PageModel
    {
        private readonly ArtistService ArtistManager;
        public ArtistModel Artist { get; private set; }

        public DetailsModel(ArtistService artistManager)
        {
            ArtistManager = artistManager;
        }

    }
}
