using Evnt_Nxt_Business_.Managers;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Model;
using Evnt_Nxt_Business_.ViewModel;


namespace Evnt_Nxt2.Pages
{

    public class ArtistModel : PageModel
    {
        private readonly ArtistManager ArtistManager;

        public List<ArtistViewModel> ArtistList { get; set; }

        // Gets the information that the ArtistModel holds.
        public ArtistModel(ArtistManager artistManager)
        {
            ArtistManager = artistManager;
        }

        public void OnGet()
        {
            ArtistList = ArtistManager.CreateArtists()
                .Select(artist => new ArtistViewModel
                {
                    ID = artist.ID,
                    Name = artist.Name,
                    Genres = artist.Genres

                }).ToList();
        }
    }
}