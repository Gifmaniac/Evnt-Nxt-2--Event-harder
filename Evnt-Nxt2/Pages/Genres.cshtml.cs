using Evnt_Nxt_Business_.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.Artist
{
    public class GenresModel : PageModel
    {
        private readonly GenreService GenreManager;
        public GenreService Genre { get; private set; }

        public GenresModel(GenreService genreManager)
        {
            GenreManager = genreManager;
        }
    }
}
