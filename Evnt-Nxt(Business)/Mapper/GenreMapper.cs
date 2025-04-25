using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt_DAL_.DTO;
using Microsoft.VisualBasic;

namespace Evnt_Nxt_Business_.Mapper
{
    public static class GenreMapper
    {
        public static GenreEnums ToEnum(string name)
        {
            return name switch
            {
                "Techno" => GenreEnums.Techno,
                "RawStyle" => GenreEnums.RawStyle,
                "Hardcore" => GenreEnums.Hardcore,
                "Uptempo" => GenreEnums.Uptempo,
                "House" => GenreEnums.House,
                "Acid" => GenreEnums.Acid,
                "EDM" => GenreEnums.EDM,
                "HardStyle" => GenreEnums.HardStyle,
                "Hard Techno" => GenreEnums.HardTechno,
                _ => throw new ArgumentException($"Genre '{name}' is not recognized.")
            };
        }

        public static string ToString(GenreEnums genreEnum)
        {
            return genreEnum switch
            {
                GenreEnums.Techno => "Techno",
                GenreEnums.RawStyle => "RawStyle",
                GenreEnums.Hardcore => "Hardcore",
                GenreEnums.Uptempo => "Uptempo",
                GenreEnums.House => "House",
                GenreEnums.Acid => "Acid",
                GenreEnums.EDM => "EDM",
                GenreEnums.HardStyle => "Hardstyle",
                GenreEnums.HardTechno => "Hard Techno",
            };
        }

        public static GenreViewModel ToViewModel(GenreDTO dto)
        {
            return new GenreViewModel()
            {
                Name = ToEnum(dto.Name)
            };
        }
    }
}
