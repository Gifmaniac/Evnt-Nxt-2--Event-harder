using Evnt_Nxt_Business_.Enums;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.Artist
{
    public class GenresModel : PageModel
    {
        private readonly GenreService GenreService;
        public GenreService Genre { get; private set; }

        public GenresModel(GenreService genreManager)
        {
            GenreService = genreManager;
        }

        public void OnGet()
        {
            var dtos = GenreService.GetAllGenres();
            var result = new List<GenreViewModel>();
            foreach (var dto in dtos)
            {
                result.Add(new GenreViewModel
                {
                    ID = dto.ID,
                    Name = Enum.Parse<GenreEnums>(dto.Name)

                });
            }
        }
    }
}
