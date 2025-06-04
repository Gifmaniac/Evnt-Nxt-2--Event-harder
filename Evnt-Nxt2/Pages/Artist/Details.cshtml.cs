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

            // Gets the artist by name
            var result = _artistService.GetArtistByName(name);

            if (!result.Success || result.Artist == null)
            {
                return NotFound();
            }

            Artist = new ArtistViewModel()
            {
                ID = result.Artist.ID,
                Name = result.Artist.Name,
            };

            return Page();
        }
    }
}
