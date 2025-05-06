using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Managers;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Model;




namespace Evnt_Nxt2.Pages
{

    public class ArtistModel : PageModel
    {
        private readonly IArtistService ArtistServices;

        public List<ArtistViewModel> ArtistList { get; set; }

        // Gets the information that the ArtistModel holds.
        public ArtistModel(IArtistService artistService)
        {
            ArtistServices = artistService;
        }

        public void OnGet()
        {
            ArtistList = ArtistServices.CreateArtist();
        }
    }
}