using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Prest.ViewModel;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;


namespace Evnt_Nxt2.Pages
{

    public class ArtistModel : PageModel
    {
        private readonly IArtistService _artistServices;

        public List<ArtistViewModel> ArtistList { get; set; }

        // Gets the information that the ArtistModel holds.
        public ArtistModel(IArtistService artistService)
        {
            _artistServices = artistService;
        }
        public void OnGet()
        {
            var artist = _artistServices.CreateAllArtist();
            ArtistList = artist.Select(artist => new ArtistViewModel
            {
                Name = artist.Name,
                Genres = artist.Genre.Select(genre => genre.ToString()).ToList()
            }).ToList();

            Console.WriteLine(ArtistList.Count);
        }
    }
}