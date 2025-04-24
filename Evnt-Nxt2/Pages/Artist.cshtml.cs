    using Microsoft.AspNetCore.Mvc;
    using Microsoft.SqlServer.Server;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Evnt_Nxt_Business_;
    using Microsoft.Extensions.WebEncoders.Testing;
    using Microsoft.IdentityModel.Tokens;
    using static System.Net.Mime.MediaTypeNames;


    namespace Evnt_Nxt2.Pages
    {

        public class ArtistModel : PageModel
        {

            // ArtistList will directly be a List of ArtistDTO
            public List<ArtistBll> ArtistList { get; private set; }
            private readonly ArtistBll artistLogic = new ArtistBll();

        public void OnGet()
            {   // Get the list of artists directly from BLL
                ArtistList = artistLogic.GetAllArtistsList();
                Console.WriteLine(ArtistList.Capacity);
                foreach (var artist in ArtistList)
                {
                    Console.WriteLine($"{artist.ID} {artist.Name}");
                }
            }
        }
    }
