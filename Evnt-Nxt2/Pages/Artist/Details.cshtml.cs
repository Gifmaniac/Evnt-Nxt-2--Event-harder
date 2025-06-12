using System.Runtime.InteropServices.JavaScript;
using Evnt_Nxt_Business_.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Prest.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Evnt_Nxt2.Pages.Artist
{
    public class DetailsModel : PageModel
    {
        private readonly IArtistService _artistService;

        public ArtistViewModel Artist { get; set; }

        public DetailsModel(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public IActionResult OnGet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound();
            }

            try
            {
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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong while loading the artist.");
                return Page();
            }
        }
    }
}
