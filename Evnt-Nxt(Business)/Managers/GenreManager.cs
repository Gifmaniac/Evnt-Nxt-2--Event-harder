using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Managers
{
   public  class GenreManager
   {
       private readonly GenreRepository GenreRepo;

       public GenreManager(GenreRepository genreRepo)
       {
           genreRepo = GenreRepo;
       }

       public List<GenreManager> GetAllGenres()
       {
           var dtos = GenreRepo.GetGenreDTOs();
           var result = new List<GenreManager>();
           foreach (var dto in dtos)
           {
                result.Add(dto);
           }
       }

   }
}
