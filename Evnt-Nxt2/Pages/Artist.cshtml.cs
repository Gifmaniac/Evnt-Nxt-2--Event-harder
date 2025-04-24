using Evnt_Nxt_Business_.Managers;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Model;


namespace Evnt_Nxt2.Pages
{

    public class ArtistModel : PageModel
    {
        private readonly ArtistManager artistManager;

        public List<ArtistViewModel> ArtistList { get; set; }

        // Gets the information that the ArtistModel holds.
        public ArtistModel(ArtistManager artistManager)
        {
            this.artistManager = artistManager;
        }

        public void OnGet()
        {
            ArtistList = artistManager.CreateArtists()
                .Select(a => new ArtistViewModel
                {
                    ID = a.ID,
                    Name = a.Name
                }).ToList();
        }
    }
}