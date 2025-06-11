using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;

namespace Evnt_Nxt_Business_.Services
{
   public  class GenreService
   {
       private readonly GenreRepository GenreRepo;

       public GenreService(GenreRepository genreRepo)
       {
           GenreRepo = genreRepo;
       }

       public List<GenreDTO> GetAllGenres()
       {
           return null;
       }

   }
}
