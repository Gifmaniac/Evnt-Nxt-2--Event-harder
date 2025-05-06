using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Managers
{
   public  class GenreService
   {
       private readonly GenreRepository GenreRepo;

       public GenreService(GenreRepository genreRepo)
       {
           GenreRepo = genreRepo;
        }

       public List<GenreViewModel> GetAllGenres()
       {
           var dtos = GenreRepo.GetGenreDTOs();
           var result = new List<GenreViewModel>();
           foreach (var dto in dtos)
           {
               result.Add(new GenreViewModel
                {
                    ID = dto.ID,
                    Name = GenreMapper.ToEnum("Name")

                });
           }
           return result;
        }

   }
}
