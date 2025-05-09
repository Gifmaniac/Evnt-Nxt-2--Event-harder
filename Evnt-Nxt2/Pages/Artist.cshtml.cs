using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Prest.ViewModel;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using System.Diagnostics;
using System.IO;


namespace Evnt_Nxt2.Pages
{

    public class ArtistModel : PageModel
    {
        private readonly ArtistService _artistServices;

        public List<ArtistViewModel> ArtistList { get; set; }

        // Gets the information that the ArtistModel holds.
        public ArtistModel(ArtistService artistService)
        {
            _artistServices = artistService;
        }

        public void OnGet()
        {
            var artist = _artistServices.CreateAllArtistsWithGenre();
            ArtistList = artist.Select(artist => new ArtistViewModel
            {
                ID = artist.ID,
                Name = artist.Name,
                Genres = artist.Genres.Select(genre => new GenreViewModel
                {

                    ID = genre.ID,
                    Name = genre.Name,
                }).ToList()
            }).ToList();
        }
    }
}