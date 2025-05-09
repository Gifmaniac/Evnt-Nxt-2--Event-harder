using Evnt_Nxt_DAL_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Prest.ViewModel;

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

        public void OnGet(string name)
        {
            var dto = _artistService.GetArtistByName(name);

            if (dto != null)
            {
                Artist = new ArtistViewModel
                {
                    ID = dto.ID,
                    Name = dto.Name
                };
            }
            else
            {
                Artist = null;
            }
        }
    }
}
