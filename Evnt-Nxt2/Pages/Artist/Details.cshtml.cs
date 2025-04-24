using Evnt_Nxt_Business_.Managers;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Model;

namespace Evnt_Nxt2.Pages.Artist
{
    public class DetailsModel : PageModel
    {
        private readonly ArtistManager artistManager;
        public ArtistModel Artist { get; private set; }

    }
}
