using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Prest.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Evnt_Nxt2.Pages.Artist
{
    public class DetailsModel : PageModel
    {
        private readonly ArtistService _artistService;

        public ArtistViewModel Artist { get; set; }

        public DetailsModel(ArtistService artistService)
        {
            _artistService = artistService;
        }

        public IActionResult OnGet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound();
            }
            var artist = _artistService.GetArtistByName(name);

            if (artist == null)
            {
                return NotFound();
            }
            else
            {
                Artist = new ArtistViewModel()
                {
                    ID = artist.ID,
                    Name = artist.Name,
                };
            }
            return Page();
        }
    }
}
