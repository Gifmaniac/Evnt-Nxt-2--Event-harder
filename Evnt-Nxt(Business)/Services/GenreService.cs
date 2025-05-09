using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Services
{
   public  class GenreService
   {
       private readonly IGenreRepository GenreRepo;

       public GenreService(IGenreRepository genreRepo)
       {
           GenreRepo = genreRepo;
       }

       public List<GenreDTO> GetAllGenres()
       {
           return null;
       }

   }
}
